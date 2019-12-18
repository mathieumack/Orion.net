/// <reference types="jquery" />
/// <reference types="kendo-ui" />

import { OrionHub } from './OrionHub';

export class OrionClient {
    connection: OrionHub;
    userName: string;
    connectionId: string;

    connectedUserCardTemplate: (data: any) => string;

    constructor(hubConnection: OrionHub,
                        userName: string,
                        connectionId: string) {
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