/// <reference types="jquery" />
/// <reference types="kendo-ui" />
/// <reference types="signalr" />
/// <reference types="node" />

import { OrionClient } from './OrionClient';
import { HubConnection } from '../../node_modules/@aspnet/signalr/src/HubConnection';
import { HubConnectionBuilder } from '../../node_modules/@aspnet/signalr/src/HubConnectionBuilder';
import { Dictionary } from '../../node_modules/linq-collections/build/src/Collections';

export class OrionHub {     
    hubUri: string;
    tabStrip: JQuery;
    connection: HubConnection;
    clients: Dictionary<string, OrionClient>;

    connectedUserDetailTemplate: (data: any) => string;
    
    constructor(uri: string, tabStripSelector : string) {  
        console.info("init orion hub");
        this.hubUri = uri;
        this.tabStrip = $(tabStripSelector);

        console.info("init orion clients");
        this.clients = new Dictionary<string, OrionClient>();

        console.info("read connected user kendo template");
        this.connectedUserDetailTemplate = kendo.template($("#connectedUserDetailTemplate").html());
    }

    connect() {
        this.connection = new HubConnectionBuilder().withUrl(this.hubUri).build();
        
        this.connection.on("newClient", function (detail: any) {
            // create a new client :
            var newclient = new OrionClient(this, detail.UserName, detail.ConnectionId);

            // Add it in the list of clients :
            this.clients.setOrUpdate(detail.ConnectionId, newclient);

            // Load client object :
            newclient.initClient();
        });

        this.connection.on("AnswerCommands", function (connectionId: string, commands: any) {
            var client = this.clients.get(connectionId);
            client.loadAvailableCommands(commands);
        });

        this.connection.start().then(function () {

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

            this.connection.invoke("AskCommands", connectionId).catch(function (err: any) {
                return console.error(err.toString());
            });

            $("#sendAskCommandsId").attr("connectionId", connectionId);
        }
    }
}