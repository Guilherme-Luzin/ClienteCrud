sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"sap/ui/model/json/JSONModel"
], function (Controller, History, JSONModel) {
	"use strict";
	return Controller.extend("sap.ui.crudCliente.Controller.Detail", {
		onInit: function () {
			var oRouter = this.getOwnerComponent().getRouter();
			oRouter.getRoute("detail").attachPatternMatched(this._onObjectMatched, this); 
		},
		
		_onObjectMatched: function (oEvent) {
			var Id = oEvent.getParameter("arguments").clientPath
			var that = this
			$.ajax({
				dataType: "json",
				type: "GET",
				data: { id: Id },
				url: "https://localhost:5001/api/Cliente/Details",
				success: function (response) {
					var ConvertedResponse = JSON.stringify(response)
					//alert(ConvertedResponse)
					console.log(response)
					that.getView().bindElement(ConvertedResponse)
				},
				error: function (response) {
					var ConvertedResponse = JSON.stringify(response)
					console.table(ConvertedResponse)
					alert("Erro ao gerar os detalhes: " + ConvertedResponse)
				}
			})
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