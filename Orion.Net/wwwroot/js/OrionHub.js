//import * as ko from "../lib/signalr/dist/signalr";
//import { Dictionary } from '../../node_modules/linq-collections/build/src/Collections';
class orionhub {
    constructor() {
    }
    test() {
        alert("hello !!");
    }
}
class orionclient {
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
//# sourceMappingURL=orionhub.js.map