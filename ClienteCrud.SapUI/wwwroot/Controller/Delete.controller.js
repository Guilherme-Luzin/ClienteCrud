sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"sap/ui/model/json/JSONModel",
	"sap/m/MessageBox"
], function (Controller, History, JSONModel, MessageBox) {
	"use strict";
	return Controller.extend("sap.ui.crudCliente.Controller.Delete", {
		onInit: function () {
			var oRouter = this.getOwnerComponent().getRouter();
			oRouter.getRoute("delete").attachPatternMatched(this._onObjectMatched, this);
		},

		onBeforeRendering: function () {
			sap.ui.getCore().getElementById("oBusyDialog").open();
		},

		_onObjectMatched: function (oEvent) {
			var that = this;
			this.Id = oEvent.getParameter("arguments").data
			$.ajax({
				dataType: "json",
				type: "GET",
				data: { id: this.Id },
				url: "https://localhost:5001/api/Cliente/GetClient",
				success: function (response) {
					var oViewModel = new JSONModel(response)
					that.getView().setModel(oViewModel, "client")
					sap.ui.getCore().getElementById("oBusyDialog").Close();
				},
				error: function (response) {
					var ConvertedResponse = JSON.stringify(response)
					MessageBox.show("Erro ao gerar os detalhes: " + ConvertedResponse, {
						icon: MessageBox.Icon.ERROR,
						title: "Erro"
					})
					sap.ui.getCore().getElementById("oBusyDialog").Close();
				}
			})
		},

		onDeleteClient: function (oEvent) {
			sap.ui.getCore().getElementById("oBusyDialog").Open();
			var that = this;
			var oRouter = that.getOwnerComponent().getRouter();
			$.ajax({
				dataType: "json",
				type: "POST",
				url: "https://localhost:5001/api/Cliente/Delete",
				data: { id: this.Id },
				success: function (response) {
					MessageBox.show("Dados deletados com sucesso", {
						onClose: oRouter.navTo("overview", {}, true),
						icon: MessageBox.Icon.SUCCESS,
						title: "Sucesso"
					})
					sap.ui.getCore().getElementById("oBusyDialog").Close();
				},
				error: function (response) {
					var ConvertedResponse = JSON.stringify(response)
					MessageBox.show("Erro ao deletar do banco: " + ConvertedResponse, {
						icon: MessageBox.Icon.ERROR,
						title: "Erro"
					})
					sap.ui.getCore().getElementById("oBusyDialog").Close();
				}
			})
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