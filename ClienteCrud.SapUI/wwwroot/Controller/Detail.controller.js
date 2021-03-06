sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"sap/ui/model/json/JSONModel",
	"sap/m/MessageBox"
], function (Controller, History, JSONModel, MessageBox) {
	"use strict";
	return Controller.extend("sap.ui.crudCliente.Controller.Detail", {
		onInit: function () {
			var oRouter = this.getOwnerComponent().getRouter();
			oRouter.getRoute("detail").attachPatternMatched(this._onObjectMatched, this); 
		},

		onBeforeRendering: function () {
			sap.ui.getCore().getElementById("oBusyDialog").open();
		},
		
		_onObjectMatched: function (oEvent) {
			window.tela = this;
			this.Id = oEvent.getParameter("arguments").data
			var that = this
			$.ajax({
				dataType: "json",
				type: "GET",
				data: { id: this.Id },
				url: "https://localhost:5001/api/Cliente/GetClient",
				success: function (response) {
					var oViewModel = new JSONModel(response)
					that.getView().setModel(oViewModel, "client")
					sap.ui.getCore().getElementById("oBusyDialog").close();
				},
				error: function (response) {
					var ConvertedResponse = JSON.stringify(response)
					console.table(ConvertedResponse)
					MessageBox.show("Erro ao gerar os detalhes: " + ConvertedResponse, {
						icon: MessageBox.Icon.ERROR,
						title: "Erro"
					})
					sap.ui.getCore().getElementById("oBusyDialog").close();
				}
			})
		},
		onEdit : function () {
			var oRouter = this.getOwnerComponent().getRouter();
			oRouter.navTo("edit", {
				data: this.Id
			});
		},

		onNavBack: function () {
			var oHistory = History.getInstance();
			var sPreviousHash = oHistory.getPreviousHash();

			if (sPreviousHash !== undefined) {
				window.history.go(-1);
			} else {
				var oRouter = this.getOwnerComponent().getRouter();
				oRouter.navTo("overview", {}, true);
			}
		}
	});
});