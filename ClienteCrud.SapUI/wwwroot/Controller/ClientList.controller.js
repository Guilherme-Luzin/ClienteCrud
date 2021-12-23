sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel",
	"sap/ui/model/resource/ResourceModel"
], function (Controller, JSONModel, ResourceModel) {
	"use strict";

	return Controller.extend("sap.ui.crudCliente.Controller.ClientList", {
		onInit: function () {
			var that = this;
			$.ajax({
				dataType: "json",
				type: "GET",
				url: "https://localhost:5001/api/Cliente/Index",
				success: function (response) {
					var oViewModel = new JSONModel({ Client: response })
					that.getView().setModel(oViewModel, "client")
				},
				error: function (response) {
					var ConvertedResponse = JSON.stringify(response)
					console.table(ConvertedResponse)
					alert("Erro ao gerar tabela: " + ConvertedResponse)
				}
			})
        },
		onCreate : function () {
			this.getOwnerComponent().getRouter().navTo("create");
		},
		onEdit : function (oEvent) {
			var bindingContext = oEvent.getSource().getBindingContext("client");
			var selectedClient = bindingContext.getObject();
			var IdView = selectedClient.id;
			var oRouter = this.getOwnerComponent().getRouter();
			oRouter.navTo("edit", {
				clientPath: IdView
			});
		},
		onDetail: function (oEvent) {
			//var oItem = oEvent.getSource();
			//var oRouter = this.getOwnerComponent().getRouter();
			//oRouter.navTo("detail", {
			//	clientPath: window.encodeURIComponent(oItem.getBindingContext("client").getPath().substr(1))
			//});
			var bindingContext = oEvent.getSource().getBindingContext("client");
			var selectedClient = bindingContext.getObject();
			var IdView = selectedClient.id;
			var oRouter = this.getOwnerComponent().getRouter();
			oRouter.navTo("detail", {
				clientPath: IdView
			});
		},
		onDelete: function (oEvent) {
			var bindingContext = oEvent.getSource().getBindingContext("client");
			var selectedClient = bindingContext.getObject();
			var IdView = selectedClient.id;
			var oRouter = this.getOwnerComponent().getRouter();
			oRouter.navTo("delete", {
				clientPath: IdView
			});
		}
	});
});