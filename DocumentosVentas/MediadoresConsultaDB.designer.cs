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
	public partial class MediadoresConsultaDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public MediadoresConsultaDBDataContext() : 
				base(global::DocumentosVentas.Properties.Settings.Default.localConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public MediadoresConsultaDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MediadoresConsultaDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MediadoresConsultaDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MediadoresConsultaDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[Function(Name="dbo.CLIENTES_MEDIADOR_SEL")]
		public ISingleResult<CLIENTES_MEDIADOR_SELResult> CLIENTES_MEDIADOR_SEL([Parameter(Name="TIPO", DbType="SmallInt")] System.Nullable<short> tIPO, [Parameter(Name="USUARIO", DbType="VarChar(15)")] string uSUARIO, [Parameter(Name="CLIE_ID", DbType="Int")] System.Nullable<int> cLIE_ID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), tIPO, uSUARIO, cLIE_ID);
			return ((ISingleResult<CLIENTES_MEDIADOR_SELResult>)(result.ReturnValue));
		}
	}
	
	public partial class CLIENTES_MEDIADOR_SELResult
	{
		
		private int _CLIE_ID;
		
		private int _REPRE_ID;
		
		private string _MEDIA_SIEMPRE;
		
		private string _APLICA_PRECIO_MEDIADOR;
		
		private string _COMUNICA;
		
		private string _REPRE_DESCRIPCION;
		
		public CLIENTES_MEDIADOR_SELResult()
		{
		}
		
		[Column(Storage="_CLIE_ID", DbType="Int NOT NULL")]
		public int CLIE_ID
		{
			get
			{
				return this._CLIE_ID;
			}
			set
			{
				if ((this._CLIE_ID != value))
				{
					this._CLIE_ID = value;
				}
			}
		}
		
		[Column(Storage="_REPRE_ID", DbType="Int NOT NULL")]
		public int REPRE_ID
		{
			get
			{
				return this._REPRE_ID;
			}
			set
			{
				if ((this._REPRE_ID != value))
				{
					this._REPRE_ID = value;
				}
			}
		}
		
		[Column(Storage="_MEDIA_SIEMPRE", DbType="VarChar(1) NOT NULL", CanBeNull=false)]
		public string MEDIA_SIEMPRE
		{
			get
			{
				return this._MEDIA_SIEMPRE;
			}
			set
			{
				if ((this._MEDIA_SIEMPRE != value))
				{
					this._MEDIA_SIEMPRE = value;
				}
			}
		}
		
		[Column(Storage="_APLICA_PRECIO_MEDIADOR", DbType="VarChar(1) NOT NULL", CanBeNull=false)]
		public string APLICA_PRECIO_MEDIADOR
		{
			get
			{
				return this._APLICA_PRECIO_MEDIADOR;
			}
			set
			{
				if ((this._APLICA_PRECIO_MEDIADOR != value))
				{
					this._APLICA_PRECIO_MEDIADOR = value;
				}
			}
		}
		
		[Column(Storage="_COMUNICA", DbType="VarChar(1) NOT NULL", CanBeNull=false)]
		public string COMUNICA
		{
			get
			{
				return this._COMUNICA;
			}
			set
			{
				if ((this._COMUNICA != value))
				{
					this._COMUNICA = value;
				}
			}
		}
		
		[Column(Storage="_REPRE_DESCRIPCION", DbType="VarChar(50)")]
		public string REPRE_DESCRIPCION
		{
			get
			{
				return this._REPRE_DESCRIPCION;
			}
			set
			{
				if ((this._REPRE_DESCRIPCION != value))
				{
					this._REPRE_DESCRIPCION = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
