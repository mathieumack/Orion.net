"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var OrionClient = /** @class */ (function () {
    function OrionClient(hubConnection, userName, connectionId) {
        this.connection = hubConnection;
        this.userName = userName;
        this.connectionId = connectionId;
        this.connectedUserCardTemplate = kendo.template($("#connectedUserCardTemplate").html());
    }
    OrionClient.prototype.initClient = function () {
        // Show client object in global list
        var clientHtml = this.connectedUserCardTemplate(this);
        $("#tabstrip").append(clientHtml);
    };
    OrionClient.prototype.loadAvailableCommands = function (commands) {
        // create DropDownList from input HTML element
        $("input[identifier = 'detailElement_commands_" + this.connectionId + "']").kendoDropDownList({
            dataTextField: "title",
            dataValueField: "title",
            dataSource: commands,
            index: 0
        });
    };
    return OrionClient;
}());
exports.OrionClient = OrionClient;
//# sourceMappingURL=OrionClient.js.map