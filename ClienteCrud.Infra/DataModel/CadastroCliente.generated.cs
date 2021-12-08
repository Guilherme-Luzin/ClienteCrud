﻿//---------------------------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated by T4Model template for T4 (https://github.com/linq2db/linq2db).
//    Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//---------------------------------------------------------------------------------------------------

#pragma warning disable 1591

using System;
using System.Linq;
using ClienteCrud.Domain;
using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Mapping;

namespace DataModels
{
	/// <summary>
	/// Database       : CadastroCliente
	/// Data Source    : INVENT017
	/// Server Version : 14.00.1000
	/// </summary>
	public partial class CadastroClienteDB : LinqToDB.Data.DataConnection
	{
		public ITable<Cliente>     Clientes    { get { return this.GetTable<Cliente>(); } }
		public ITable<VersionInfo> VersionInfo { get { return this.GetTable<VersionInfo>(); } }

		public CadastroClienteDB()
		{
			InitDataContext();
			InitMappingSchema();
		}

		public CadastroClienteDB(string configuration)
			: base(configuration)
		{
			InitDataContext();
			InitMappingSchema();
		}

		public CadastroClienteDB(LinqToDbConnectionOptions options)
			: base(options)
		{
			InitDataContext();
			InitMappingSchema();
		}

		public CadastroClienteDB(LinqToDbConnectionOptions<CadastroClienteDB> options)
			: base(options)
		{
			InitDataContext();
			InitMappingSchema();
		}

		partial void InitDataContext  ();
		partial void InitMappingSchema();
	}

	//[Table(Schema="dbo", Name="Cliente")]
	//public partial class Cliente
	//{
	//	[PrimaryKey, Identity] public int    Id    { get; set; } // int
	//	[Column,     NotNull ] public string Nome  { get; set; } // nvarchar(255)
	//	[Column,     NotNull ] public int    Idade { get; set; } // int
	//	[Column,     NotNull ] public string Email { get; set; } // nvarchar(255)
	//}

	[Table(Schema="dbo", Name="VersionInfo")]
	public partial class VersionInfo
	{
		[Column, NotNull    ] public long      Version     { get; set; } // bigint
		[Column,    Nullable] public DateTime? AppliedOn   { get; set; } // datetime
		[Column,    Nullable] public string    Description { get; set; } // nvarchar(1024)
	}

	public static partial class TableExtensions
	{
		public static Cliente Find(this ITable<Cliente> table, int Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}
	}
}

#pragma warning restore 1591
