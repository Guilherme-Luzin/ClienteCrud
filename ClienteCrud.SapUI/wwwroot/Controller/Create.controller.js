sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"sap/ui/model/json/JSONModel"
], function (Controller, History, JSONModel) {
	"use strict";
	return Controller.extend("sap.ui.crudCliente.Controller.Create", {
		onInit: function () {
			var oRouter = this.getOwnerComponent().getRouter();
			oRouter.getRoute("edit").attachPatternMatched(this._onObjectMatched, this);
		},
		_onObjectMatched: function (oEvent) {
			var Id = oEvent.getParameter("arguments").data
			var that = this;
			$.ajax({
				dataType: "json",
				type: "GET",
				data: { id: Id },
				url: "https://localhost:5001/api/Cliente/GetClient",
				success: function (response) {
					var oViewModel = new JSONModel(response)
					that.getView().setModel(oViewModel, "client")
				},
				error: function (response) {
					var ConvertedResponse = JSON.stringify(response)
					console.table(ConvertedResponse)
					alert("Erro ao gerar tabela: " + ConvertedResponse)
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
			var id = this.getView().byId("inId").setValue(null);
			var nome = this.getView().byId("inNome").setValue(null);
			var email = this.getView().byId("inEmail").setValue(null);
			var idade = this.getView().byId("inIdade").setValue(null);

			this.getView().byId("inNome").setValueState(sap.ui.core.ValueState.None);
			this.getView().byId("inEmail").setValueState(sap.ui.core.ValueState.None);
			this.getView().byId("inIdade").setValueState(sap.ui.core.ValueState.None);
		},
		onAddClient: function () {
			var id = this.getView().byId("inId").getValue();
			var nome = this.getView().byId("inNome").getValue();
			var email = this.getView().byId("inEmail").getValue();
			var idade = this.getView().byId("inIdade").getValue();

			var mailregex = /^\w+[\w-+\.]*\@\w+([-\.]\w+)*\.[a-zA-Z]{2,}$/;

			if (nome == "") {
				alert("O nome não pode ficar em branco")
				this.getView().byId("inNome").setValueState(sap.ui.core.ValueState.Error);
			}
			else if (email == "") {
				alert("O email não pode ficar em branco")
				this.getView().byId("inEmail").setValueState(sap.ui.core.ValueState.Error);
			}
			else if (!mailregex.test(email)) {

				alert("Insira um e-mail válido! \nexemplo@exemplo.exemplo");

				this.getView().byId("inEmail").setValueState(sap.ui.core.ValueState.Error);
			}
			else if (idade == "") {
				alert("A idade não pode ficar em branco e deve conter apenas NÚMEROS")
				this.getView().byId("inIdade").setValueState(sap.ui.core.ValueState.Error);
			}
			else {
				var cliente = {
					Id: id,
					Nome: nome,
					Email: email,
					Idade: idade
				}	

				$.ajax({
					dataType: "json",
					type: "POST",
					url: "https://localhost:5001/api/Cliente/Create",
					data: { cliente: cliente },
					success: function (response) {
						alert("Dados salvos com sucesso ")
						window.location.replace("Index.html")
					},
					error: function (response) {
						var ConvertedResponse = JSON.stringify(response)
						console.table(response)
						alert("Erro ao salvar no banco: " + ConvertedResponse)
						console.log(cliente)
					}
				})
			}
		}
	});
});
