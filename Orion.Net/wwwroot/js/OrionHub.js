"use strict";
/// <reference types="jquery" />
/// <reference types="kendo-ui" />
/// <reference types="signalr" />
/// <reference types="node" />
Object.defineProperty(exports, "__esModule", { value: true });
var OrionClient_1 = require("./OrionClient");
var signalr_1 = require("../../node_modules/@aspnet/signalr");
var Collections_1 = require("linq-collections/build/src/Collections");
var OrionHub = /** @class */ (function () {
    function OrionHub(uri, tabStripObject) {
        this.hubUri = uri;
        this.tabStrip = tabStripObject;
        this.clients = new Collections_1.Dictionary();
        this.connectedUserDetailTemplate = kendo.template($("#connectedUserDetailTemplate").html());
    }
    OrionHub.prototype.connect = function () {
        this.connection = new signalr_1.HubConnectionBuilder().withUrl("/orionhub").build();
        this.connection.on("newClient", function (detail) {
            // create a new client :
            var newclient = new OrionClient_1.OrionClient(this, detail.UserName, detail.ConnectionId);
            // Add it in the list of clients :
            this.clients.setOrUpdate(detail.ConnectionId, newclient);
            // Load client object :
            newclient.initClient();
        });
        this.connection.on("AnswerCommands", function (connectionId, commands) {
            var client = this.clients.get(connectionId);
            client.loadAvailableCommands(commands);
        });
        this.connection.start().then(function () {
        }).catch(function (err) {
            return console.error(err.toString());
        });
    };
    OrionHub.prototype.loadClient = function (connectionId) {
        $(".currentConnectionDetail").each(function () {
            $(this).hide();
        });
        $("div[identifier='detailElement_" + connectionId + "']").show();
        if ($("div[identifier='detailElement_" + connectionId + "']").length == 0) {
            var html = this.connectedUserDetailTemplate(this);
            $("#blocCurrentConnection").append(html);
            this.connection.invoke("AskCommands", connectionId).catch(function (err) {
                return console.error(err.toString());
            });
            $("#sendAskCommandsId").attr("connectionId", connectionId);
        }
    };
    return OrionHub;
}());
exports.OrionHub = OrionHub;
//# sourceMappingURL=OrionHub.js.map