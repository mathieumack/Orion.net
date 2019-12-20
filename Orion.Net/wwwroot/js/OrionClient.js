/// <reference types="jquery" />
/// <reference types="kendo-ui" />
export class OrionClient {
    constructor(hubConnection, userName, connectionId) {
        this.connection = hubConnection;
        this.userName = userName;
        this.connectionId = connectionId;
        this.connectedUserCardTemplate = kendo.template($("#connectedUserCardTemplate").html());
    }
    initClient() {
        // Show client object in global list
        var clientHtml = this.connectedUserCardTemplate(this);
        $("#tabstrip").append(clientHtml);
    }
    loadAvailableCommands(commands) {
        // create DropDownList from input HTML element
        $("input[identifier = 'detailElement_commands_" + this.connectionId + "']").kendoDropDownList({
            dataTextField: "title",
            dataValueField: "title",
            dataSource: commands,
            index: 0
        });
    }
}
//# sourceMappingURL=OrionClient.js.map