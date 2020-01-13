//import * as ko from "../lib/signalr/dist/signalr";
//import { Dictionary } from '../../node_modules/linq-collections/build/src/Collections';

class orionhub {     
    constructor() {
    } 

    test() {
        alert("hello !!");
    }
    //hubUri: string;
    //tabStrip: JQuery; 
    //connection: SignalR.Hub.Proxy;
    //clients: Dictionary<string, orionclient>;

    //connectedUserDetailTemplate: (data: any) => string;
    
    //constructor(uri: string, tabStripSelector: string, connection: SignalR.Hub.Proxy) {  
    //    console.info("init orion hub");
    //    this.connection = connection;
    //    this.hubUri = uri;
    //    this.tabStrip = $(tabStripSelector);

    //    console.info("init orion clients");
    //    this.clients = new Dictionary<string, orionclient>();

    //    console.info("read connected user kendo template");
    //    this.connectedUserDetailTemplate = kendo.template($("#connectedUserDetailTemplate").html());
    //}

    //configure() {        
    //    this.connection.on("newClient", function (detail: any) {
    //        // create a new client :
    //        var newclient = new orionclient(this, detail.UserName, detail.ConnectionId);

    //        // Add it in the list of clients :
    //        this.clients.setOrUpdate(detail.ConnectionId, newclient);

    //        // Load client object :
    //        newclient.initClient();
    //    });

    //    this.connection.on("AnswerCommands", function (connectionId: string, commands: any) {
    //        var client = this.clients.get(connectionId);
    //        client.loadAvailableCommands(commands);
    //    });
    //}

    //loadClient(connectionId: string) {
    //    $(".currentConnectionDetail").each(function () {
    //        $(this).hide();
    //    });
    //    $("div[identifier='detailElement_" + connectionId + "']").show();

    //    if ($("div[identifier='detailElement_" + connectionId + "']").length == 0) {
    //        var html = this.connectedUserDetailTemplate(this);
    //        $("#blocCurrentConnection").append(html);

    //        this.connection.invoke("AskCommands", connectionId).catch(function (err: any) {
    //            return console.error(err.toString());
    //        });

    //        $("#sendAskCommandsId").attr("connectionId", connectionId);
    //    }
    //}
}


class orionclient {
    connection: orionhub;
    userName: string;
    connectionId: string;

    connectedUserCardTemplate: (data: any) => string;

    constructor(hubConnection: orionhub,
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

    loadAvailableCommands(commands: any) {
        // create DropDownList from input HTML element
        $("input[identifier = 'detailElement_commands_" + this.connectionId + "']").kendoDropDownList({
            dataTextField: "title",
            dataValueField: "title",
            dataSource: commands,
            index: 0
        });
    }
}