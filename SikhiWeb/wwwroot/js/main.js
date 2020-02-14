"use strict";
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/gurbaniconnect")
    .configureLogging(signalR.LogLevel.Information)
    .build();

function initApp() {
    var app = new Vue({
        el: '#app',
        data: {
            lines: []
        },
        methods: {
            fetchGurbani: function () {
                const vueInstance = this;
                connection.on("FetchLines", function (lines) {
                    vueInstance.lines = lines;
                });
                connection.invoke("FetchLines").catch(function (err) {
                    return console.error(err.toString());
                });
            }
        },
        beforeMount() {
            this.fetchGurbani();
        }
    });
}
connection.start().then(function () {
    initApp();
}).catch(function (err) {
    return console.error(err.toString());
});