sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History"
], function (Controller, History) {
	"use strict";
	return Controller.extend("sap.ui.crudCliente.Controller.Delete", {
		onInit: function () {
			var oRouter = this.getOwnerComponent().getRouter();
			oRouter.getRoute("delete").attachPatternMatched(this._onObjectMatched, this);
		},
		_onObjectMatched: function (oEvent) {
			//this.getView().bindElement({
			//	path: "/" + window.decodeURIComponent(oEvent.getParameter("arguments").clientPath),
			//	model: "client"
			//});
			//var Id = oEvent.getParameter("arguments").clientPath
			this.Id = oEvent.getParameter("arguments").clientPath
			$.ajax({
				dataType: "json",
				type: "GET",
				data: { id: this.Id },
				url: "https://localhost:5001/api/Cliente/Delete",
				success: function (response) {
					// var ConvertedResponse = JSON.stringify(response)
					//alert(ConvertedResponse)
					console.log(response)
				},
				error: function (response) {
					var ConvertedResponse = JSON.stringify(response)
					console.table(ConvertedResponse)
					alert("Erro ao gerar os detalhes: " + ConvertedResponse)
				}
			})
		},

		onDeleteClient: function (oEvent) {
			var IdDelete = this.Id
			$.ajax({
				dataType: "json",
				type: "POST",
				url: "https://localhost:5001/api/Cliente/Delete",
				data: { id: IdDelete },
				success: function (response) {
					alert("Dados deletados com sucesso ")
					window.location.replace("Index.html")
				},
				error: function (response) {
					var ConvertedResponse = JSON.stringify(response)
					console.table(response)
					alert("Erro ao deletar do banco: " + ConvertedResponse)
					console.log(cliente)
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