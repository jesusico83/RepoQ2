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
	public partial class TiposIRPFConsultaDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public TiposIRPFConsultaDBDataContext() : 
				base(global::DocumentosVentas.Properties.Settings.Default.localConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public TiposIRPFConsultaDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TiposIRPFConsultaDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TiposIRPFConsultaDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TiposIRPFConsultaDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[Function(Name="dbo.IRPF_CON")]
		public ISingleResult<IRPF_CONResult> IRPF_CON([Parameter(Name="TIPO", DbType="SmallInt")] System.Nullable<short> tIPO, [Parameter(Name="USUARIO", DbType="VarChar(15)")] string uSUARIO)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), tIPO, uSUARIO);
			return ((ISingleResult<IRPF_CONResult>)(result.ReturnValue));
		}
	}
	
	public partial class IRPF_CONResult
	{
		
		private int _IRPF_ID;
		
		private string _IRPF_DESCRIPCION;
		
		public IRPF_CONResult()
		{
		}
		
		[Column(Storage="_IRPF_ID", DbType="Int NOT NULL")]
		public int IRPF_ID
		{
			get
			{
				return this._IRPF_ID;
			}
			set
			{
				if ((this._IRPF_ID != value))
				{
					this._IRPF_ID = value;
				}
			}
		}
		
		[Column(Storage="_IRPF_DESCRIPCION", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string IRPF_DESCRIPCION
		{
			get
			{
				return this._IRPF_DESCRIPCION;
			}
			set
			{
				if ((this._IRPF_DESCRIPCION != value))
				{
					this._IRPF_DESCRIPCION = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
