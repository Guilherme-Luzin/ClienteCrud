sap.ui.define([
	"sap/ui/core/ComponentContainer"
], function (ComponentContainer) {
	"use strict";

	new ComponentContainer({
		name: "sap.ui.crudCliente",
		settings : {
			id : "crudCliente"
		},
		async: true
	}).placeAt("content");
});
