sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel",
	"sap/ui/model/Filter",
	"sap/ui/model/FilterOperator"
], function (Controller, JSONModel, Filter, FilterOperator) {
	"use strict";

	return Controller.extend("sap.ui.crudCliente.Controller.ClientList", {
		onInit: function () {
			var oRouter = this.getOwnerComponent().getRouter();
			oRouter.getRoute("overview").attachPatternMatched(this._onObjectMatched, this);
		},

		_onObjectMatched: function () {
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
		onFilterClient: function (oEvent) {
			// build filter array
			var nFilter = [];
			var sQuery = oEvent.getParameter("query");
			if (sQuery) {
				nFilter.push(new Filter("nome", FilterOperator.Contains, sQuery));
			}

			// filter binding
			var oTable = this.byId("ClientTable");
			var oBinding = oTable.getBinding("items");
			oBinding.filter(nFilter);
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
				data: IdView
			});
		},
		onDetail: function (oEvent) {
			var bindingContext = oEvent.getSource().getBindingContext("client");
			var selectedClient = bindingContext.getObject();
			var IdView = selectedClient.id;
			var oRouter = this.getOwnerComponent().getRouter();
			oRouter.navTo("detail", {
				data: IdView
			});
		},
		onDelete: function (oEvent) {
			var bindingContext = oEvent.getSource().getBindingContext("client");
			var selectedClient = bindingContext.getObject();
			var IdView = selectedClient.id;
			var oRouter = this.getOwnerComponent().getRouter();
			oRouter.navTo("delete", {
				data: IdView
			});
		}
	});
});