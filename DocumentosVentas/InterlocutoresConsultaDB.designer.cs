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
	public partial class InterlocutoresConsultaDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCLIENTES_INTER(CLIENTES_INTER instance);
    partial void UpdateCLIENTES_INTER(CLIENTES_INTER instance);
    partial void DeleteCLIENTES_INTER(CLIENTES_INTER instance);
    #endregion
		
		public InterlocutoresConsultaDBDataContext() : 
				base(global::DocumentosVentas.Properties.Settings.Default.localConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public InterlocutoresConsultaDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public InterlocutoresConsultaDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public InterlocutoresConsultaDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public InterlocutoresConsultaDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<CLIENTES_INTER> CLIENTES_INTER
		{
			get
			{
				return this.GetTable<CLIENTES_INTER>();
			}
		}
		
		[Function(Name="dbo.CLIENTES_INTER_SEL")]
		public ISingleResult<CLIENTES_INTER_SELResult> CLIENTES_INTER_SEL([Parameter(Name="TIPO", DbType="SmallInt")] System.Nullable<short> tIPO, [Parameter(Name="USUARIO", DbType="VarChar(15)")] string uSUARIO, [Parameter(Name="CLIE_ID", DbType="Int")] System.Nullable<int> cLIE_ID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), tIPO, uSUARIO, cLIE_ID);
			return ((ISingleResult<CLIENTES_INTER_SELResult>)(result.ReturnValue));
		}
		
		[Function(Name="dbo.CLIENTES_INTER_Q2_SEL")]
		public ISingleResult<CLIENTES_INTER_Q2_SELResult> CLIENTES_INTER_Q2_SEL([Parameter(Name="TIPO", DbType="SmallInt")] System.Nullable<short> tIPO, [Parameter(Name="USUARIO", DbType="VarChar(15)")] string uSUARIO, [Parameter(Name="CLIE_ID", DbType="Int")] System.Nullable<int> cLIE_ID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), tIPO, uSUARIO, cLIE_ID);
			return ((ISingleResult<CLIENTES_INTER_Q2_SELResult>)(result.ReturnValue));
		}
		
		[Function(Name="dbo.CLIENTES_INTER_Q2_SEL1")]
		public ISingleResult<CLIENTES_INTER_Q2_SEL1Result> CLIENTES_INTER_Q2_SEL1([Parameter(Name="TIPO", DbType="SmallInt")] System.Nullable<short> tIPO, [Parameter(Name="USUARIO", DbType="VarChar(15)")] string uSUARIO, [Parameter(Name="CLIE_ID", DbType="Int")] System.Nullable<int> cLIE_ID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), tIPO, uSUARIO, cLIE_ID);
			return ((ISingleResult<CLIENTES_INTER_Q2_SEL1Result>)(result.ReturnValue));
		}
	}
	
	[Table(Name="dbo.CLIENTES_INTER")]
	public partial class CLIENTES_INTER : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _CLIE_ID;
		
		private int _CLIEI_ID;
		
		private string _DEPAE_ID;
		
		private string _TINTE_ID;
		
		private string _CLIEI_NOMBRE;
		
		private string _CLIEI_TELEFONO;
		
		private string _CLIEI_MOVIL;
		
		private string _CLIEI_FAX;
		
		private string _CLIEI_EMAIL;
		
		private char _CLIEI_EC;
		
		private char _CLIEI_EM;
		
		private char _CLIEI_EF;
		
		private char _CLIEI_ES;
		
		private char _CLIEI_EW;
		
		private bool _ACTIVO;
		
		private string _ANOTACIONES;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCLIE_IDChanging(int value);
    partial void OnCLIE_IDChanged();
    partial void OnCLIEI_IDChanging(int value);
    partial void OnCLIEI_IDChanged();
    partial void OnDEPAE_IDChanging(string value);
    partial void OnDEPAE_IDChanged();
    partial void OnTINTE_IDChanging(string value);
    partial void OnTINTE_IDChanged();
    partial void OnCLIEI_NOMBREChanging(string value);
    partial void OnCLIEI_NOMBREChanged();
    partial void OnCLIEI_TELEFONOChanging(string value);
    partial void OnCLIEI_TELEFONOChanged();
    partial void OnCLIEI_MOVILChanging(string value);
    partial void OnCLIEI_MOVILChanged();
    partial void OnCLIEI_FAXChanging(string value);
    partial void OnCLIEI_FAXChanged();
    partial void OnCLIEI_EMAILChanging(string value);
    partial void OnCLIEI_EMAILChanged();
    partial void OnCLIEI_ECChanging(char value);
    partial void OnCLIEI_ECChanged();
    partial void OnCLIEI_EMChanging(char value);
    partial void OnCLIEI_EMChanged();
    partial void OnCLIEI_EFChanging(char value);
    partial void OnCLIEI_EFChanged();
    partial void OnCLIEI_ESChanging(char value);
    partial void OnCLIEI_ESChanged();
    partial void OnCLIEI_EWChanging(char value);
    partial void OnCLIEI_EWChanged();
    partial void OnACTIVOChanging(bool value);
    partial void OnACTIVOChanged();
    partial void OnANOTACIONESChanging(string value);
    partial void OnANOTACIONESChanged();
    #endregion
		
		public CLIENTES_INTER()
		{
			OnCreated();
		}
		
		[Column(Storage="_CLIE_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
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
					this.OnCLIE_IDChanging(value);
					this.SendPropertyChanging();
					this._CLIE_ID = value;
					this.SendPropertyChanged("CLIE_ID");
					this.OnCLIE_IDChanged();
				}
			}
		}
		
		[Column(Storage="_CLIEI_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int CLIEI_ID
		{
			get
			{
				return this._CLIEI_ID;
			}
			set
			{
				if ((this._CLIEI_ID != value))
				{
					this.OnCLIEI_IDChanging(value);
					this.SendPropertyChanging();
					this._CLIEI_ID = value;
					this.SendPropertyChanged("CLIEI_ID");
					this.OnCLIEI_IDChanged();
				}
			}
		}
		
		[Column(Storage="_DEPAE_ID", DbType="VarChar(6) NOT NULL", CanBeNull=false)]
		public string DEPAE_ID
		{
			get
			{
				return this._DEPAE_ID;
			}
			set
			{
				if ((this._DEPAE_ID != value))
				{
					this.OnDEPAE_IDChanging(value);
					this.SendPropertyChanging();
					this._DEPAE_ID = value;
					this.SendPropertyChanged("DEPAE_ID");
					this.OnDEPAE_IDChanged();
				}
			}
		}
		
		[Column(Storage="_TINTE_ID", DbType="VarChar(6) NOT NULL", CanBeNull=false)]
		public string TINTE_ID
		{
			get
			{
				return this._TINTE_ID;
			}
			set
			{
				if ((this._TINTE_ID != value))
				{
					this.OnTINTE_IDChanging(value);
					this.SendPropertyChanging();
					this._TINTE_ID = value;
					this.SendPropertyChanged("TINTE_ID");
					this.OnTINTE_IDChanged();
				}
			}
		}
		
		[Column(Storage="_CLIEI_NOMBRE", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string CLIEI_NOMBRE
		{
			get
			{
				return this._CLIEI_NOMBRE;
			}
			set
			{
				if ((this._CLIEI_NOMBRE != value))
				{
					this.OnCLIEI_NOMBREChanging(value);
					this.SendPropertyChanging();
					this._CLIEI_NOMBRE = value;
					this.SendPropertyChanged("CLIEI_NOMBRE");
					this.OnCLIEI_NOMBREChanged();
				}
			}
		}
		
		[Column(Storage="_CLIEI_TELEFONO", DbType="VarChar(15) NOT NULL", CanBeNull=false)]
		public string CLIEI_TELEFONO
		{
			get
			{
				return this._CLIEI_TELEFONO;
			}
			set
			{
				if ((this._CLIEI_TELEFONO != value))
				{
					this.OnCLIEI_TELEFONOChanging(value);
					this.SendPropertyChanging();
					this._CLIEI_TELEFONO = value;
					this.SendPropertyChanged("CLIEI_TELEFONO");
					this.OnCLIEI_TELEFONOChanged();
				}
			}
		}
		
		[Column(Storage="_CLIEI_MOVIL", DbType="VarChar(15) NOT NULL", CanBeNull=false)]
		public string CLIEI_MOVIL
		{
			get
			{
				return this._CLIEI_MOVIL;
			}
			set
			{
				if ((this._CLIEI_MOVIL != value))
				{
					this.OnCLIEI_MOVILChanging(value);
					this.SendPropertyChanging();
					this._CLIEI_MOVIL = value;
					this.SendPropertyChanged("CLIEI_MOVIL");
					this.OnCLIEI_MOVILChanged();
				}
			}
		}
		
		[Column(Storage="_CLIEI_FAX", DbType="VarChar(15) NOT NULL", CanBeNull=false)]
		public string CLIEI_FAX
		{
			get
			{
				return this._CLIEI_FAX;
			}
			set
			{
				if ((this._CLIEI_FAX != value))
				{
					this.OnCLIEI_FAXChanging(value);
					this.SendPropertyChanging();
					this._CLIEI_FAX = value;
					this.SendPropertyChanged("CLIEI_FAX");
					this.OnCLIEI_FAXChanged();
				}
			}
		}
		
		[Column(Storage="_CLIEI_EMAIL", DbType="VarChar(105) NOT NULL", CanBeNull=false)]
		public string CLIEI_EMAIL
		{
			get
			{
				return this._CLIEI_EMAIL;
			}
			set
			{
				if ((this._CLIEI_EMAIL != value))
				{
					this.OnCLIEI_EMAILChanging(value);
					this.SendPropertyChanging();
					this._CLIEI_EMAIL = value;
					this.SendPropertyChanged("CLIEI_EMAIL");
					this.OnCLIEI_EMAILChanged();
				}
			}
		}
		
		[Column(Storage="_CLIEI_EC", DbType="VarChar(1) NOT NULL")]
		public char CLIEI_EC
		{
			get
			{
				return this._CLIEI_EC;
			}
			set
			{
				if ((this._CLIEI_EC != value))
				{
					this.OnCLIEI_ECChanging(value);
					this.SendPropertyChanging();
					this._CLIEI_EC = value;
					this.SendPropertyChanged("CLIEI_EC");
					this.OnCLIEI_ECChanged();
				}
			}
		}
		
		[Column(Storage="_CLIEI_EM", DbType="VarChar(1) NOT NULL")]
		public char CLIEI_EM
		{
			get
			{
				return this._CLIEI_EM;
			}
			set
			{
				if ((this._CLIEI_EM != value))
				{
					this.OnCLIEI_EMChanging(value);
					this.SendPropertyChanging();
					this._CLIEI_EM = value;
					this.SendPropertyChanged("CLIEI_EM");
					this.OnCLIEI_EMChanged();
				}
			}
		}
		
		[Column(Storage="_CLIEI_EF", DbType="VarChar(1) NOT NULL")]
		public char CLIEI_EF
		{
			get
			{
				return this._CLIEI_EF;
			}
			set
			{
				if ((this._CLIEI_EF != value))
				{
					this.OnCLIEI_EFChanging(value);
					this.SendPropertyChanging();
					this._CLIEI_EF = value;
					this.SendPropertyChanged("CLIEI_EF");
					this.OnCLIEI_EFChanged();
				}
			}
		}
		
		[Column(Storage="_CLIEI_ES", DbType="VarChar(1) NOT NULL")]
		public char CLIEI_ES
		{
			get
			{
				return this._CLIEI_ES;
			}
			set
			{
				if ((this._CLIEI_ES != value))
				{
					this.OnCLIEI_ESChanging(value);
					this.SendPropertyChanging();
					this._CLIEI_ES = value;
					this.SendPropertyChanged("CLIEI_ES");
					this.OnCLIEI_ESChanged();
				}
			}
		}
		
		[Column(Storage="_CLIEI_EW", DbType="VarChar(1) NOT NULL")]
		public char CLIEI_EW
		{
			get
			{
				return this._CLIEI_EW;
			}
			set
			{
				if ((this._CLIEI_EW != value))
				{
					this.OnCLIEI_EWChanging(value);
					this.SendPropertyChanging();
					this._CLIEI_EW = value;
					this.SendPropertyChanged("CLIEI_EW");
					this.OnCLIEI_EWChanged();
				}
			}
		}
		
		[Column(Storage="_ACTIVO", DbType="Bit NOT NULL")]
		public bool ACTIVO
		{
			get
			{
				return this._ACTIVO;
			}
			set
			{
				if ((this._ACTIVO != value))
				{
					this.OnACTIVOChanging(value);
					this.SendPropertyChanging();
					this._ACTIVO = value;
					this.SendPropertyChanged("ACTIVO");
					this.OnACTIVOChanged();
				}
			}
		}
		
		[Column(Storage="_ANOTACIONES", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string ANOTACIONES
		{
			get
			{
				return this._ANOTACIONES;
			}
			set
			{
				if ((this._ANOTACIONES != value))
				{
					this.OnANOTACIONESChanging(value);
					this.SendPropertyChanging();
					this._ANOTACIONES = value;
					this.SendPropertyChanged("ANOTACIONES");
					this.OnANOTACIONESChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	public partial class CLIENTES_INTER_SELResult
	{
		
		private int _CLIE_ID;
		
		private int _CLIEI_ID;
		
		private string _DEPAE_ID;
		
		private string _TINTE_ID;
		
		private string _CLIEI_NOMBRE;
		
		private string _CLIEI_TELEFONO;
		
		private string _CLIEI_MOVIL;
		
		private string _CLIEI_FAX;
		
		private string _CLIEI_EMAIL;
		
		private string _CLIEI_EC;
		
		private string _CLIEI_EM;
		
		private string _CLIEI_EF;
		
		private string _CLIEI_ES;
		
		private string _CLIEI_EW;
		
		private string _ANOTACIONES;
		
		public CLIENTES_INTER_SELResult()
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
		
		[Column(Storage="_CLIEI_ID", DbType="Int NOT NULL")]
		public int CLIEI_ID
		{
			get
			{
				return this._CLIEI_ID;
			}
			set
			{
				if ((this._CLIEI_ID != value))
				{
					this._CLIEI_ID = value;
				}
			}
		}
		
		[Column(Storage="_DEPAE_ID", DbType="VarChar(6) NOT NULL", CanBeNull=false)]
		public string DEPAE_ID
		{
			get
			{
				return this._DEPAE_ID;
			}
			set
			{
				if ((this._DEPAE_ID != value))
				{
					this._DEPAE_ID = value;
				}
			}
		}
		
		[Column(Storage="_TINTE_ID", DbType="VarChar(6) NOT NULL", CanBeNull=false)]
		public string TINTE_ID
		{
			get
			{
				return this._TINTE_ID;
			}
			set
			{
				if ((this._TINTE_ID != value))
				{
					this._TINTE_ID = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_NOMBRE", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string CLIEI_NOMBRE
		{
			get
			{
				return this._CLIEI_NOMBRE;
			}
			set
			{
				if ((this._CLIEI_NOMBRE != value))
				{
					this._CLIEI_NOMBRE = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_TELEFONO", DbType="VarChar(15) NOT NULL", CanBeNull=false)]
		public string CLIEI_TELEFONO
		{
			get
			{
				return this._CLIEI_TELEFONO;
			}
			set
			{
				if ((this._CLIEI_TELEFONO != value))
				{
					this._CLIEI_TELEFONO = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_MOVIL", DbType="VarChar(15) NOT NULL", CanBeNull=false)]
		public string CLIEI_MOVIL
		{
			get
			{
				return this._CLIEI_MOVIL;
			}
			set
			{
				if ((this._CLIEI_MOVIL != value))
				{
					this._CLIEI_MOVIL = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_FAX", DbType="VarChar(15) NOT NULL", CanBeNull=false)]
		public string CLIEI_FAX
		{
			get
			{
				return this._CLIEI_FAX;
			}
			set
			{
				if ((this._CLIEI_FAX != value))
				{
					this._CLIEI_FAX = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_EMAIL", DbType="VarChar(105) NOT NULL", CanBeNull=false)]
		public string CLIEI_EMAIL
		{
			get
			{
				return this._CLIEI_EMAIL;
			}
			set
			{
				if ((this._CLIEI_EMAIL != value))
				{
					this._CLIEI_EMAIL = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_EC", DbType="VarChar(1) NOT NULL", CanBeNull=false)]
		public string CLIEI_EC
		{
			get
			{
				return this._CLIEI_EC;
			}
			set
			{
				if ((this._CLIEI_EC != value))
				{
					this._CLIEI_EC = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_EM", DbType="VarChar(1) NOT NULL", CanBeNull=false)]
		public string CLIEI_EM
		{
			get
			{
				return this._CLIEI_EM;
			}
			set
			{
				if ((this._CLIEI_EM != value))
				{
					this._CLIEI_EM = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_EF", DbType="VarChar(1) NOT NULL", CanBeNull=false)]
		public string CLIEI_EF
		{
			get
			{
				return this._CLIEI_EF;
			}
			set
			{
				if ((this._CLIEI_EF != value))
				{
					this._CLIEI_EF = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_ES", DbType="VarChar(1) NOT NULL", CanBeNull=false)]
		public string CLIEI_ES
		{
			get
			{
				return this._CLIEI_ES;
			}
			set
			{
				if ((this._CLIEI_ES != value))
				{
					this._CLIEI_ES = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_EW", DbType="VarChar(1) NOT NULL", CanBeNull=false)]
		public string CLIEI_EW
		{
			get
			{
				return this._CLIEI_EW;
			}
			set
			{
				if ((this._CLIEI_EW != value))
				{
					this._CLIEI_EW = value;
				}
			}
		}
		
		[Column(Storage="_ANOTACIONES", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string ANOTACIONES
		{
			get
			{
				return this._ANOTACIONES;
			}
			set
			{
				if ((this._ANOTACIONES != value))
				{
					this._ANOTACIONES = value;
				}
			}
		}
	}
	
	public partial class CLIENTES_INTER_Q2_SELResult
	{
		
		private int _CLIE_ID;
		
		private int _CLIEI_ID;
		
		private string _DEPAE_ID;
		
		private string _TINTE_ID;
		
		private string _CLIEI_NOMBRE;
		
		private string _CLIEI_TELEFONO;
		
		private string _CLIEI_MOVIL;
		
		private string _CLIEI_FAX;
		
		private string _CLIEI_EMAIL;
		
		private char _CLIEI_EC;
		
		private System.Nullable<bool> _CLIEI_ECB;
		
		private char _CLIEI_EM;
		
		private System.Nullable<bool> _CLIEI_EMB;
		
		private char _CLIEI_EF;
		
		private System.Nullable<bool> _CLIEI_EFB;
		
		private char _CLIEI_ES;
		
		private System.Nullable<bool> _CLIEI_ESB;
		
		private char _CLIEI_EW;
		
		private System.Nullable<bool> _CLIEI_EWB;
		
		private string _ANOTACIONES;
		
		public CLIENTES_INTER_Q2_SELResult()
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
		
		[Column(Storage="_CLIEI_ID", DbType="Int NOT NULL")]
		public int CLIEI_ID
		{
			get
			{
				return this._CLIEI_ID;
			}
			set
			{
				if ((this._CLIEI_ID != value))
				{
					this._CLIEI_ID = value;
				}
			}
		}
		
		[Column(Storage="_DEPAE_ID", DbType="VarChar(6) NOT NULL", CanBeNull=false)]
		public string DEPAE_ID
		{
			get
			{
				return this._DEPAE_ID;
			}
			set
			{
				if ((this._DEPAE_ID != value))
				{
					this._DEPAE_ID = value;
				}
			}
		}
		
		[Column(Storage="_TINTE_ID", DbType="VarChar(6) NOT NULL", CanBeNull=false)]
		public string TINTE_ID
		{
			get
			{
				return this._TINTE_ID;
			}
			set
			{
				if ((this._TINTE_ID != value))
				{
					this._TINTE_ID = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_NOMBRE", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string CLIEI_NOMBRE
		{
			get
			{
				return this._CLIEI_NOMBRE;
			}
			set
			{
				if ((this._CLIEI_NOMBRE != value))
				{
					this._CLIEI_NOMBRE = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_TELEFONO", DbType="VarChar(15) NOT NULL", CanBeNull=false)]
		public string CLIEI_TELEFONO
		{
			get
			{
				return this._CLIEI_TELEFONO;
			}
			set
			{
				if ((this._CLIEI_TELEFONO != value))
				{
					this._CLIEI_TELEFONO = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_MOVIL", DbType="VarChar(15) NOT NULL", CanBeNull=false)]
		public string CLIEI_MOVIL
		{
			get
			{
				return this._CLIEI_MOVIL;
			}
			set
			{
				if ((this._CLIEI_MOVIL != value))
				{
					this._CLIEI_MOVIL = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_FAX", DbType="VarChar(15) NOT NULL", CanBeNull=false)]
		public string CLIEI_FAX
		{
			get
			{
				return this._CLIEI_FAX;
			}
			set
			{
				if ((this._CLIEI_FAX != value))
				{
					this._CLIEI_FAX = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_EMAIL", DbType="VarChar(105) NOT NULL", CanBeNull=false)]
		public string CLIEI_EMAIL
		{
			get
			{
				return this._CLIEI_EMAIL;
			}
			set
			{
				if ((this._CLIEI_EMAIL != value))
				{
					this._CLIEI_EMAIL = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_EC", DbType="VarChar(1) NOT NULL")]
		public char CLIEI_EC
		{
			get
			{
				return this._CLIEI_EC;
			}
			set
			{
				if ((this._CLIEI_EC != value))
				{
					this._CLIEI_EC = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_ECB", DbType="Bit")]
		public System.Nullable<bool> CLIEI_ECB
		{
			get
			{
				return this._CLIEI_ECB;
			}
			set
			{
				if ((this._CLIEI_ECB != value))
				{
					this._CLIEI_ECB = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_EM", DbType="VarChar(1) NOT NULL")]
		public char CLIEI_EM
		{
			get
			{
				return this._CLIEI_EM;
			}
			set
			{
				if ((this._CLIEI_EM != value))
				{
					this._CLIEI_EM = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_EMB", DbType="Bit")]
		public System.Nullable<bool> CLIEI_EMB
		{
			get
			{
				return this._CLIEI_EMB;
			}
			set
			{
				if ((this._CLIEI_EMB != value))
				{
					this._CLIEI_EMB = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_EF", DbType="VarChar(1) NOT NULL")]
		public char CLIEI_EF
		{
			get
			{
				return this._CLIEI_EF;
			}
			set
			{
				if ((this._CLIEI_EF != value))
				{
					this._CLIEI_EF = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_EFB", DbType="Bit")]
		public System.Nullable<bool> CLIEI_EFB
		{
			get
			{
				return this._CLIEI_EFB;
			}
			set
			{
				if ((this._CLIEI_EFB != value))
				{
					this._CLIEI_EFB = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_ES", DbType="VarChar(1) NOT NULL")]
		public char CLIEI_ES
		{
			get
			{
				return this._CLIEI_ES;
			}
			set
			{
				if ((this._CLIEI_ES != value))
				{
					this._CLIEI_ES = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_ESB", DbType="Bit")]
		public System.Nullable<bool> CLIEI_ESB
		{
			get
			{
				return this._CLIEI_ESB;
			}
			set
			{
				if ((this._CLIEI_ESB != value))
				{
					this._CLIEI_ESB = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_EW", DbType="VarChar(1) NOT NULL")]
		public char CLIEI_EW
		{
			get
			{
				return this._CLIEI_EW;
			}
			set
			{
				if ((this._CLIEI_EW != value))
				{
					this._CLIEI_EW = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_EWB", DbType="Bit")]
		public System.Nullable<bool> CLIEI_EWB
		{
			get
			{
				return this._CLIEI_EWB;
			}
			set
			{
				if ((this._CLIEI_EWB != value))
				{
					this._CLIEI_EWB = value;
				}
			}
		}
		
		[Column(Storage="_ANOTACIONES", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string ANOTACIONES
		{
			get
			{
				return this._ANOTACIONES;
			}
			set
			{
				if ((this._ANOTACIONES != value))
				{
					this._ANOTACIONES = value;
				}
			}
		}
	}
	
	public partial class CLIENTES_INTER_Q2_SEL1Result
	{
		
		private int _CLIE_ID;
		
		private int _CLIEI_ID;
		
		private string _DEPAE_ID;
		
		private string _TINTE_ID;
		
		private string _CLIEI_NOMBRE;
		
		private string _CLIEI_TELEFONO;
		
		private string _CLIEI_MOVIL;
		
		private string _CLIEI_FAX;
		
		private string _CLIEI_EMAIL;
		
		private char _CLIEI_EC;
		
		private System.Nullable<bool> _CLIEI_ECB;
		
		private char _CLIEI_EM;
		
		private System.Nullable<bool> _CLIEI_EMB;
		
		private char _CLIEI_EF;
		
		private System.Nullable<bool> _CLIEI_EFB;
		
		private char _CLIEI_ES;
		
		private System.Nullable<bool> _CLIEI_ESB;
		
		private char _CLIEI_EW;
		
		private System.Nullable<bool> _CLIEI_EWB;
		
		private bool _ACTIVO;
		
		private string _ANOTACIONES;
		
		public CLIENTES_INTER_Q2_SEL1Result()
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
		
		[Column(Storage="_CLIEI_ID", DbType="Int NOT NULL")]
		public int CLIEI_ID
		{
			get
			{
				return this._CLIEI_ID;
			}
			set
			{
				if ((this._CLIEI_ID != value))
				{
					this._CLIEI_ID = value;
				}
			}
		}
		
		[Column(Storage="_DEPAE_ID", DbType="VarChar(6) NOT NULL", CanBeNull=false)]
		public string DEPAE_ID
		{
			get
			{
				return this._DEPAE_ID;
			}
			set
			{
				if ((this._DEPAE_ID != value))
				{
					this._DEPAE_ID = value;
				}
			}
		}
		
		[Column(Storage="_TINTE_ID", DbType="VarChar(6) NOT NULL", CanBeNull=false)]
		public string TINTE_ID
		{
			get
			{
				return this._TINTE_ID;
			}
			set
			{
				if ((this._TINTE_ID != value))
				{
					this._TINTE_ID = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_NOMBRE", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string CLIEI_NOMBRE
		{
			get
			{
				return this._CLIEI_NOMBRE;
			}
			set
			{
				if ((this._CLIEI_NOMBRE != value))
				{
					this._CLIEI_NOMBRE = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_TELEFONO", DbType="VarChar(15) NOT NULL", CanBeNull=false)]
		public string CLIEI_TELEFONO
		{
			get
			{
				return this._CLIEI_TELEFONO;
			}
			set
			{
				if ((this._CLIEI_TELEFONO != value))
				{
					this._CLIEI_TELEFONO = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_MOVIL", DbType="VarChar(15) NOT NULL", CanBeNull=false)]
		public string CLIEI_MOVIL
		{
			get
			{
				return this._CLIEI_MOVIL;
			}
			set
			{
				if ((this._CLIEI_MOVIL != value))
				{
					this._CLIEI_MOVIL = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_FAX", DbType="VarChar(15) NOT NULL", CanBeNull=false)]
		public string CLIEI_FAX
		{
			get
			{
				return this._CLIEI_FAX;
			}
			set
			{
				if ((this._CLIEI_FAX != value))
				{
					this._CLIEI_FAX = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_EMAIL", DbType="VarChar(105) NOT NULL", CanBeNull=false)]
		public string CLIEI_EMAIL
		{
			get
			{
				return this._CLIEI_EMAIL;
			}
			set
			{
				if ((this._CLIEI_EMAIL != value))
				{
					this._CLIEI_EMAIL = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_EC", DbType="VarChar(1) NOT NULL")]
		public char CLIEI_EC
		{
			get
			{
				return this._CLIEI_EC;
			}
			set
			{
				if ((this._CLIEI_EC != value))
				{
					this._CLIEI_EC = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_ECB", DbType="Bit")]
		public System.Nullable<bool> CLIEI_ECB
		{
			get
			{
				return this._CLIEI_ECB;
			}
			set
			{
				if ((this._CLIEI_ECB != value))
				{
					this._CLIEI_ECB = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_EM", DbType="VarChar(1) NOT NULL")]
		public char CLIEI_EM
		{
			get
			{
				return this._CLIEI_EM;
			}
			set
			{
				if ((this._CLIEI_EM != value))
				{
					this._CLIEI_EM = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_EMB", DbType="Bit")]
		public System.Nullable<bool> CLIEI_EMB
		{
			get
			{
				return this._CLIEI_EMB;
			}
			set
			{
				if ((this._CLIEI_EMB != value))
				{
					this._CLIEI_EMB = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_EF", DbType="VarChar(1) NOT NULL")]
		public char CLIEI_EF
		{
			get
			{
				return this._CLIEI_EF;
			}
			set
			{
				if ((this._CLIEI_EF != value))
				{
					this._CLIEI_EF = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_EFB", DbType="Bit")]
		public System.Nullable<bool> CLIEI_EFB
		{
			get
			{
				return this._CLIEI_EFB;
			}
			set
			{
				if ((this._CLIEI_EFB != value))
				{
					this._CLIEI_EFB = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_ES", DbType="VarChar(1) NOT NULL")]
		public char CLIEI_ES
		{
			get
			{
				return this._CLIEI_ES;
			}
			set
			{
				if ((this._CLIEI_ES != value))
				{
					this._CLIEI_ES = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_ESB", DbType="Bit")]
		public System.Nullable<bool> CLIEI_ESB
		{
			get
			{
				return this._CLIEI_ESB;
			}
			set
			{
				if ((this._CLIEI_ESB != value))
				{
					this._CLIEI_ESB = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_EW", DbType="VarChar(1) NOT NULL")]
		public char CLIEI_EW
		{
			get
			{
				return this._CLIEI_EW;
			}
			set
			{
				if ((this._CLIEI_EW != value))
				{
					this._CLIEI_EW = value;
				}
			}
		}
		
		[Column(Storage="_CLIEI_EWB", DbType="Bit")]
		public System.Nullable<bool> CLIEI_EWB
		{
			get
			{
				return this._CLIEI_EWB;
			}
			set
			{
				if ((this._CLIEI_EWB != value))
				{
					this._CLIEI_EWB = value;
				}
			}
		}
		
		[Column(Storage="_ACTIVO", DbType="Bit NOT NULL")]
		public bool ACTIVO
		{
			get
			{
				return this._ACTIVO;
			}
			set
			{
				if ((this._ACTIVO != value))
				{
					this._ACTIVO = value;
				}
			}
		}
		
		[Column(Storage="_ANOTACIONES", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string ANOTACIONES
		{
			get
			{
				return this._ANOTACIONES;
			}
			set
			{
				if ((this._ANOTACIONES != value))
				{
					this._ANOTACIONES = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
