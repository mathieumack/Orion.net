/// <reference types="jquery" />
/// <reference types="kendo-ui" />
/// <reference types="signalr" />
/// <reference types="node" />

import { OrionClient } from './OrionClient';
import { HubConnection, HubConnectionBuilder } from '../../node_modules/@aspnet/signalr';
import { Dictionary } from 'linq-collections/build/src/Collections';

export class OrionHub {

    hubUri: string;
    tabStrip: JQuery;
    connection: HubConnection;
    clients: Dictionary<string, OrionClient>;

    connectedUserDetailTemplate: (data: any) => string;
    
    constructor(uri: string, tabStripObject: JQuery) {
        this.hubUri = uri;
        this.tabStrip = tabStripObject;
        this.clients = new Dictionary<string, OrionClient>();

        this.connectedUserDetailTemplate = kendo.template($("#connectedUserDetailTemplate").html());
    }

    connect() {
        this.connection = new HubConnectionBuilder().withUrl("/orionhub").build();
        
        this.connection.on("newClient", function (detail) {
            // create a new client :
            var newclient = new OrionClient(this, detail.UserName, detail.ConnectionId);

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
    }

    loadClient(connectionId: string) {
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
    }
}