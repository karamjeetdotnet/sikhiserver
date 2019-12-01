using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SikhiDB.Models;
using SikhiLib.Interfaces;
using SikhiLib.Models;
using MySql.Data.EntityFrameworkCore;

namespace SikhiJsonMySqlConsole
{
    class Program
    {
        const string BaniPath = @"G:\Storage Space\visualStudio\startuped\database-master\database-master\data\";
        const string ConnectionString = "server=localhost;port=3306;user=root;password=root;database=gurbanidb";
        //static SikhiDBContext dBContext;
        static DbContextOptions<SikhiDBContext> dbOptions;
        static List<bani_index> bani_Indices;
        static List<bani_index_range> bani_Index_Ranges;
        static List<bani_text> bani_Texts;
        static List<bani_text_line> bani_Text_Lines;
        static List<file_source> file_Sources;
        static List<languages> languages;
        static List<locale> locales;
        static List<source_index> source_Indices;
        static List<source_index_range> source_Index_Ranges;
        static List<translation_source> translation_Sources;
        static List<writer> writers;
        static void Main(string[] args)
        {
            Init();
            using (SikhiDBContext dBContext = new SikhiDBContext(dbOptions))
            {
                bani_text_line baniText = new bani_text_line();
                baniText.gurbani_db_id = "testb3";
                baniText.bani_text_id = 6241;
                baniText.source_page = 1;
                baniText.source_line = 1;
                baniText.gurmukhi = "<> siq nwmu krqw purKu inrBau inrvYru; Akwl mUriq AjUnI sYBM gur pRswid ]";
                baniText.pronunciation = "ਭੁਖਿਆਂ, ਪੁਰੀਆਂ";
                baniText.pronunciation_information = "ਭੁਖਿਆ ਭੁਖ - ਭੁਖਿਆਂ ਦੀ ਭੁਖ ਨਹੀਂ ਉਤਰਦੀ ਭਾਂਵੇਂ ਉਹ ਕਿਨੀਆਂ ਵੀ ਪੁਰੀਆਂ ਦੇ ਪਦਾਰਥਾਂ ਦੇ ਭਾਰ ਬੰਨ ਲੈਣ।";
                baniText.translation = "test";
                baniText.file_source_id = 2006;
                dBContext.Add(baniText);
                dBContext.SaveChanges();
            }//test unicode support
            return;
            ReadFiles(BaniPath);
            ReadDirectories(BaniPath);
            Console.WriteLine("Import Completed");
            Console.Read();
        }
        static void Init() {
            DbContextOptionsBuilder<SikhiDBContext> dbContextOptions = new DbContextOptionsBuilder<SikhiDBContext>();
            dbContextOptions.UseMySQL(ConnectionString);
			dbOptions = dbContextOptions.Options;
			//dBContext = new SikhiDBContext(dbOptions.Options);
			bani_Indices = new List<bani_index>();
            bani_Index_Ranges = new List<bani_index_range>();
            bani_Texts = new List<bani_text>();
            bani_Text_Lines = new List<bani_text_line>();
            file_Sources = new List<file_source>();
            languages = new List<languages>();
            locales = new List<locale>();
            source_Indices = new List<source_index>();
            source_Index_Ranges = new List<source_index_range>();
            translation_Sources = new List<translation_source>();
            writers = new List<writer>();
        }
        static void ReadDirectories(string path) {
            foreach (var directoryPath in Directory.GetDirectories(path))
            {
                ReadFiles(directoryPath);
            }
        }
        static void ReadFiles(string directory) {
            foreach (var file in Directory.GetFiles(directory)) {
                ReadFile(file);
            }
        }
        static void ReadFile(string file) {
            string direnctoryName = Path.GetDirectoryName(file);
            string parentDirectoryPath = Path.GetDirectoryName(direnctoryName);
            direnctoryName = direnctoryName.Replace(parentDirectoryPath + "\\", "");
            string fileContent = File.ReadAllText(file);
            ProcessDirectory(Path.GetFileName(file), fileContent, (direnctoryName == "data") ? "ROOT" : direnctoryName);
        }
        static file_source GetFileSouce(string fileName, string fileContent, string sourceDirectory) {
            return new file_source
            {
                file_name = fileName,
                content = fileContent,
                source = sourceDirectory
            };
        }
        static void ProcessDirectory(string fileName, string fileContent, string sourceDirectory) {
            file_source fileSource;
            using (SikhiDBContext dBContext = new SikhiDBContext(dbOptions)) {
                fileSource = GetFileSouce(fileName, fileContent, sourceDirectory);
                file_Sources.Add(fileSource);
                dBContext.Add(fileSource);
                dBContext.SaveChanges();
            }            
            Console.WriteLine(string.Format("Processing file {0} from {1}", fileName, sourceDirectory));
            switch (fileName)
            {
                case "banis.json":
                    ProcessBanies(JsonConvert.DeserializeObject<List<Bani>>(fileContent), fileSource);
                    break;
                case "languages.json":
                case "writers.json":
                    ProcessLanguages(JsonConvert.DeserializeObject<List<Locale>>(fileContent), (fileName == "writers.json"), fileSource);
                    break;
                case "sources.json":
                    ProcessSources(JsonConvert.DeserializeObject<List<Source>>(fileContent), fileSource);
                    break;
                case "translation_sources.json":
                    ProcessTranslationSources(JsonConvert.DeserializeObject<List<TranslationSource>>(fileContent), fileSource);
                    break;
                default:
                    ProcessBaniDirectory(JsonConvert.DeserializeObject<List<Text>>(fileContent), fileSource);
                    break;
            }
        }
        static List<bani_text_line> GetBaniTextLines(long baniTextId, List<TextLine> lines, file_source fileSource) {
            List<bani_text_line> textLines = new List<bani_text_line>();
            Console.WriteLine("processing GetBaniTextLines");
            using (SikhiDBContext dBContext = new SikhiDBContext(dbOptions))
            {
                foreach (var item in lines)
                {
                    Console.WriteLine("processed GetBaniTextLines " + item.GurbaniDbId);
                    textLines.Add(new bani_text_line
                    {
                        file_source_id = fileSource.id,
                        gurbani_db_id = item.GurbaniDbId,
                        gurmukhi = item.Gurmukhi,
                        source_line = item.SourceLine,
                        source_page = item.SourcePage,
                        bani_text_id = baniTextId,
                        pronunciation = item.Pronunciation,
                        pronunciation_information = item.PronunciationInformation,
                        translation = item.Translation
                    });
                }
                dBContext.AddRange(textLines);
                dBContext.SaveChanges();
            }
            Console.WriteLine("processed GetBaniTextLines");
            return textLines;
        }
        static void ProcessBaniDirectory(List<Text> baniTexts, file_source fileSource) {
            Console.WriteLine("processing ProcessBaniDirectory");
            using (SikhiDBContext dBContext = new SikhiDBContext(dbOptions))
            {
                bani_Texts = new List<bani_text>();
                foreach (var text in baniTexts)
                {
                    long? sectionId = null, subsectionId = null;
                    source_index_range sourceIndexRange = source_Index_Ranges.Find(x => x.locale_.english == text.Section && !x.is_subsection);
                    if (sourceIndexRange != null)
                        sectionId = sourceIndexRange.id;
                    source_index_range subSourceIndexRange = source_Index_Ranges.Find(x => x.locale_.english == text.SubSection && x.is_subsection);
                    if (subSourceIndexRange != null)
                        subsectionId = subSourceIndexRange.id;

                    Console.WriteLine("processed " + text.GurbaniDbId);
                    bani_text baniText = new bani_text
                    {
                        sttm_id = text.SttmId,
                        section_source_id = sectionId,
                        subsection_source_id = subsectionId,
                        file_source_id = fileSource.id,
                        gurbani_db_id = text.GurbaniDbId,
                        writer_id = writers.Find(x => x.locale_.english == text.Writer).id
                    };
                    dBContext.Add(baniText);
                    dBContext.SaveChanges();
                    GetBaniTextLines(baniText.id, text.Lines, fileSource);
                    bani_Texts.Add(baniText);
                }
                
            }
            Console.WriteLine("processed ProcessBaniDirectory");
        }
        static List<bani_index_range> GetBaniRanges(List<SikhiLib.Models.Range> lines, file_source fileSource) {
            List<bani_index_range> localRanges = new List<bani_index_range>();
            foreach (var item in lines)
            {
                localRanges.Add(new bani_index_range {
                    file_source_id = fileSource.id,
                    end = item.EndLine,
                    start = item.StartLine
                });
            }
            return localRanges;
        }
        static void ProcessBanies(List<Bani> banis, file_source fileSource) {
            Console.WriteLine("in process banis");
            using (SikhiDBContext dBContext = new SikhiDBContext(dbOptions))
            {
                foreach (Bani bani in banis)
                {
                    Console.WriteLine(bani.GurmukhiName);
                    bani_Indices.Add(new bani_index {
                        locale_ = new locale {
                            english = bani.EnglishName,
                            gurmukhi = bani.GurmukhiName,
                            internatinal = bani.InternationalName
                        },
                        file_source_id = fileSource.id,
                        bani_index_range = GetBaniRanges(bani.Lines, fileSource)
                    });
                }
                dBContext.AddRange(bani_Indices);
                dBContext.SaveChanges();
            }
            Console.Write("processed banis");
        }
        static void ProcessLanguages(List<Locale> dLocales, bool isWriter, file_source fileSource)
        {
            Console.WriteLine("processing languages");
            using (SikhiDBContext dBContext = new SikhiDBContext(dbOptions))
            {
                foreach (Locale locale in dLocales)
                {
                    Console.WriteLine(locale.GurmukhiName);
                    if (isWriter)
                    {
                        writers.Add(new writer
                        {
                            locale_ = new locale
                            {
                                english = locale.EnglishName,
                                gurmukhi = locale.GurmukhiName,
                                internatinal = locale.InternationalName
                            },
                            file_source_id = fileSource.id
                        });
                    }
                    else
                    {
                        languages.Add(new languages
                        {
                            locale_ = new locale
                            {
                                english = locale.EnglishName,
                                gurmukhi = locale.GurmukhiName,
                                internatinal = locale.InternationalName
                            },
                            file_source_id = fileSource.id
                        });
                    }
                }
                if (isWriter) { dBContext.AddRange(writers); } else { dBContext.AddRange(languages); }
                dBContext.SaveChanges();
            }
            Console.WriteLine("processed languages");
        }
        static void GetSourceIndexRanges(long sourceId, long? sourceRangeId, 
            List<Section> sections, file_source fileSource, bool isSubsection = false) {
            //List<source_index_range> sourceIndexRanges = new List<source_index_range>();
            Console.WriteLine("processing GetSourceIndexRanges");
            if (sections == null)
                sections = new List<Section>();
            using (SikhiDBContext dBContext = new SikhiDBContext(dbOptions))
            {
                foreach (var section in sections)
                {
                    Console.WriteLine(string.Format("processed GetSourceIndexRanges section {0}-{1}", section.StartPage ?? 0, section.EndPage ?? 0));
                    source_index_range sourceIndexRange = new source_index_range
                    {
                        description = section.Description,
                        end_page = section.EndPage,
                        file_source_id = fileSource.id,
                        source_index_id = sourceId,
                        source_index_range_id = sourceRangeId,
                        is_subsection = isSubsection,
                        locale_ = new locale
                        {
                            english = section.EnglishName,
                            gurmukhi = section.GurmukhiName,
                            internatinal = section.InternationalName
                        },
                        start_page = section.StartPage
                    };
                    dBContext.Add(sourceIndexRange);
                    dBContext.SaveChanges();
                    GetSourceIndexRanges(sourceId, sourceIndexRange.id, section.SubSections, fileSource, true);
                    source_Index_Ranges.Add(sourceIndexRange);
                }
            }
            Console.WriteLine("processed GetSourceIndexRanges");
            //return sourceIndexRanges;
        }
        static void ProcessSources(List<Source> sources, file_source fileSource)
        {
            Console.WriteLine("processing sources");
            using (SikhiDBContext dBContext = new SikhiDBContext(dbOptions))
            {
                foreach (Source source in sources)
                {
                    Console.WriteLine(source.GurmukhiPageName);
                    source_index sourceIndex = new source_index
                    {
                        english_page_name = source.EnglishPageName,
                        file_source_id = fileSource.id,
                        gurmukhi_page_name = source.GurmukhiPageName,
                        length = source.Length,
                        locale_ = new locale
                        {
                            english = source.EnglishName,
                            gurmukhi = source.GurmukhiName,
                            internatinal = source.InternationalName
                        }
                    };
                    dBContext.Add(sourceIndex);
                    dBContext.SaveChanges();
                    GetSourceIndexRanges(sourceIndex.id, null, source.Sections, fileSource);
                    source_Indices.Add(sourceIndex);
                }
                //dBContext.AddRange(source_Indices);
                
            }
            Console.WriteLine("processed sources");
        }
        static void ProcessTranslationSources(List<TranslationSource> sources, file_source fileSource)
        {
            Console.WriteLine("processing ProcessTranslationSources");
            using (SikhiDBContext dBContext = new SikhiDBContext(dbOptions))
            {
                foreach (TranslationSource source in sources)
                {
                    source_index idx = source_Indices.Find(x => x.locale_.english == source.Source);
                    Console.WriteLine(source.GurmukhiName);
                    translation_Sources.Add(new translation_source
                    {
                        file_source_id = fileSource.id,
                        language = source.Language,
                        locale_ = new locale
                        {
                            english = source.EnglishName,
                            gurmukhi = source.GurmukhiName,
                            internatinal = source.InternationalName
                        },
                        source_index_id = ((idx == null) ? null : (long?)idx.id)
                    });
                }
                dBContext.AddRange(translation_Sources);
                dBContext.SaveChanges();
            }
            Console.WriteLine("processed ProcessTranslationSources");
        }
    }
}
