﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión del motor en tiempo de ejecución:2.0.50727.5477
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DocumentosVentas
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name="local")]
	public partial class DocumentosConsultaDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public DocumentosConsultaDBDataContext() : 
				base(global::DocumentosVentas.Properties.Settings.Default.localConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DocumentosConsultaDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DocumentosConsultaDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DocumentosConsultaDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DocumentosConsultaDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[Function(Name="dbo.DOCUMENTOS_CON_TIPOS")]
		public ISingleResult<DOCUMENTOS_CON_TIPOSResult> DOCUMENTOS_CON_TIPOS([Parameter(Name="TIPO", DbType="SmallInt")] System.Nullable<short> tIPO, [Parameter(Name="USUARIO", DbType="VarChar(15)")] string uSUARIO, [Parameter(Name="TIDOC_ID", DbType="VarChar(6)")] string tIDOC_ID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), tIPO, uSUARIO, tIDOC_ID);
			return ((ISingleResult<DOCUMENTOS_CON_TIPOSResult>)(result.ReturnValue));
		}
	}
	
	public partial class DOCUMENTOS_CON_TIPOSResult
	{
		
		private string _TIDOC_ID;
		
		private string _DOCU_ID;
		
		private string _DOCU_DESCRIPCION;
		
		public DOCUMENTOS_CON_TIPOSResult()
		{
		}
		
		[Column(Storage="_TIDOC_ID", DbType="VarChar(6) NOT NULL", CanBeNull=false)]
		public string TIDOC_ID
		{
			get
			{
				return this._TIDOC_ID;
			}
			set
			{
				if ((this._TIDOC_ID != value))
				{
					this._TIDOC_ID = value;
				}
			}
		}
		
		[Column(Storage="_DOCU_ID", DbType="VarChar(6) NOT NULL", CanBeNull=false)]
		public string DOCU_ID
		{
			get
			{
				return this._DOCU_ID;
			}
			set
			{
				if ((this._DOCU_ID != value))
				{
					this._DOCU_ID = value;
				}
			}
		}
		
		[Column(Storage="_DOCU_DESCRIPCION", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string DOCU_DESCRIPCION
		{
			get
			{
				return this._DOCU_DESCRIPCION;
			}
			set
			{
				if ((this._DOCU_DESCRIPCION != value))
				{
					this._DOCU_DESCRIPCION = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
