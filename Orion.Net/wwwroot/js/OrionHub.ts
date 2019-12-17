/// <reference path="../../node_modules/@types/jquery/JQuery.d.ts" />

function sayHello() {
    //var compiler = (document.getElementById("compiler") as HTMLInputElement).value;
    //var framework = (document.getElementById("framework") as HTMLInputElement).value;
    //return `Hello from ${compiler} and ${framework}!`;
    alert("Hello");
}

class OrionHub {

    hubUri: string;
    tabStrip: JQuery;

    constructor(uri: string, tabStripObject: JQuery) {
        this.hubUri = uri;
        this.tabStrip = tabStripObject;
    }

    Connect() {
        this.tabStrip.html('bonjour');
        //var connection = new signalR.HubConnectionBuilder().withUrl("/orionhub").build();

        //connection.on("newClient", function (detail) {
        //    tabStrip.append(connectedUserCardTemplate(detail));
        //});

        //connection.on("AnswerCommands", function (connectionId, commands) {
        //    loadAvailableCommands(connectionId, commands);
        //});

        //connection.start().then(function () {

        //}).catch(function (err) {
        //    return console.error(err.toString());
        //});
    }
}