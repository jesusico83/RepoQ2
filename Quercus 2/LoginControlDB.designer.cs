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

namespace Quercus_2
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
	public partial class LoginControlDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public LoginControlDBDataContext() : 
				base(global::Quercus_2.Properties.Settings.Default.localConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public LoginControlDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LoginControlDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LoginControlDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LoginControlDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[Function(Name="dbo.USUARIOS_Q2_SEL_PWD")]
		public ISingleResult<USUARIOS_Q2_SEL_PWDResult> USUARIOS_Q2_SEL_PWD([Parameter(Name="USU_ID", DbType="VarChar(15)")] string uSU_ID, [Parameter(Name="USU_PWD", DbType="VarChar(28)")] string uSU_PWD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), uSU_ID, uSU_PWD);
			return ((ISingleResult<USUARIOS_Q2_SEL_PWDResult>)(result.ReturnValue));
		}
	}
	
	public partial class USUARIOS_Q2_SEL_PWDResult
	{
		
		private string _USU_ID;
		
		private string _PESE_ID;
		
		private string _USU_DESCRIPCION;
		
		private int _USU_ID1;
		
		public USUARIOS_Q2_SEL_PWDResult()
		{
		}
		
		[Column(Storage="_USU_ID", DbType="VarChar(15) NOT NULL", CanBeNull=false)]
		public string USU_ID
		{
			get
			{
				return this._USU_ID;
			}
			set
			{
				if ((this._USU_ID != value))
				{
					this._USU_ID = value;
				}
			}
		}
		
		[Column(Storage="_PESE_ID", DbType="VarChar(15)")]
		public string PESE_ID
		{
			get
			{
				return this._PESE_ID;
			}
			set
			{
				if ((this._PESE_ID != value))
				{
					this._PESE_ID = value;
				}
			}
		}
		
		[Column(Storage="_USU_DESCRIPCION", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string USU_DESCRIPCION
		{
			get
			{
				return this._USU_DESCRIPCION;
			}
			set
			{
				if ((this._USU_DESCRIPCION != value))
				{
					this._USU_DESCRIPCION = value;
				}
			}
		}
		
		[Column(Storage="_USU_ID1", DbType="Int NOT NULL")]
		public int USU_ID1
		{
			get
			{
				return this._USU_ID1;
			}
			set
			{
				if ((this._USU_ID1 != value))
				{
					this._USU_ID1 = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
