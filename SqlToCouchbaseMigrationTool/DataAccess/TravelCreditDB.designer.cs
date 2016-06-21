﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18063
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="mTravelCredit")]
	public partial class TravelCreditDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public TravelCreditDBDataContext() : 
				base(global::DataAccess.Properties.Settings.Default.mTravelCreditConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public TravelCreditDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TravelCreditDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TravelCreditDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TravelCreditDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.spMemberExistsInMemberDetails")]
		public ISingleResult<spMemberExistsInMemberDetailsResult> spMemberExistsInMemberDetails([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Username", DbType="VarChar(500)")] string username)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), username);
			return ((ISingleResult<spMemberExistsInMemberDetailsResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.spInsertMemberInMemberDetails")]
		public int spInsertMemberInMemberDetails([global::System.Data.Linq.Mapping.ParameterAttribute(Name="MemberName", DbType="NVarChar(MAX)")] string memberName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="MemberShips", DbType="NVarChar(MAX)")] string memberShips, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="MemberShipStatus", DbType="NVarChar(MAX)")] string memberShipStatus, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="MemberCountry", DbType="NVarChar(MAX)")] string memberCountry)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), memberName, memberShips, memberShipStatus, memberCountry);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.spGetTranscationDetails")]
		public ISingleResult<spGetTranscationDetailsResult> spGetTranscationDetails([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(500)")] string memberName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="StartDate", DbType="DateTime")] System.Nullable<System.DateTime> startDate, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="EndDate", DbType="DateTime")] System.Nullable<System.DateTime> endDate)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), memberName, startDate, endDate);
			return ((ISingleResult<spGetTranscationDetailsResult>)(result.ReturnValue));
		}
	}
	
	public partial class spMemberExistsInMemberDetailsResult
	{
		
		private string _MemberName;
		
		private string _MemberShips;
		
		private string _MemberShipStatus;
		
		private string _MemberCountry;
		
		private System.Nullable<long> _Code;
		
		public spMemberExistsInMemberDetailsResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MemberName", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string MemberName
		{
			get
			{
				return this._MemberName;
			}
			set
			{
				if ((this._MemberName != value))
				{
					this._MemberName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MemberShips", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string MemberShips
		{
			get
			{
				return this._MemberShips;
			}
			set
			{
				if ((this._MemberShips != value))
				{
					this._MemberShips = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MemberShipStatus", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string MemberShipStatus
		{
			get
			{
				return this._MemberShipStatus;
			}
			set
			{
				if ((this._MemberShipStatus != value))
				{
					this._MemberShipStatus = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MemberCountry", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string MemberCountry
		{
			get
			{
				return this._MemberCountry;
			}
			set
			{
				if ((this._MemberCountry != value))
				{
					this._MemberCountry = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Code", DbType="BigInt")]
		public System.Nullable<long> Code
		{
			get
			{
				return this._Code;
			}
			set
			{
				if ((this._Code != value))
				{
					this._Code = value;
				}
			}
		}
	}
	
	public partial class spGetTranscationDetailsResult
	{
		
		private System.Guid _TransactionId;
		
		private System.Nullable<System.Guid> _ReferenceTransactionId;
		
		private string _TransactionType;
		
		private string _Currency;
		
		private System.Nullable<decimal> _Amount;
		
		private int _ConversionFactor;
		
		private System.Nullable<decimal> _UsdEquivalentAmount;
		
		private string _SoftcashProgram;
		
		private System.Nullable<System.DateTime> _Timestamp;
		
		private string _Reason;
		
		private string _Comment;
		
		private System.Nullable<System.DateTime> _Validity;
		
		private string _Availability;
		
		private string _TransactionStatus;
		
		private decimal _ClosingBalance;
		
		private string _RequesterUserName;
		
		private string _OrderId;
		
		private string _Application;
		
		private string _Username;
		
		public spGetTranscationDetailsResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TransactionId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid TransactionId
		{
			get
			{
				return this._TransactionId;
			}
			set
			{
				if ((this._TransactionId != value))
				{
					this._TransactionId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ReferenceTransactionId", DbType="UniqueIdentifier")]
		public System.Nullable<System.Guid> ReferenceTransactionId
		{
			get
			{
				return this._ReferenceTransactionId;
			}
			set
			{
				if ((this._ReferenceTransactionId != value))
				{
					this._ReferenceTransactionId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TransactionType", DbType="VarChar(200)")]
		public string TransactionType
		{
			get
			{
				return this._TransactionType;
			}
			set
			{
				if ((this._TransactionType != value))
				{
					this._TransactionType = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Currency", DbType="VarChar(200)")]
		public string Currency
		{
			get
			{
				return this._Currency;
			}
			set
			{
				if ((this._Currency != value))
				{
					this._Currency = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Amount", DbType="Decimal(18,2)")]
		public System.Nullable<decimal> Amount
		{
			get
			{
				return this._Amount;
			}
			set
			{
				if ((this._Amount != value))
				{
					this._Amount = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ConversionFactor", DbType="Int NOT NULL")]
		public int ConversionFactor
		{
			get
			{
				return this._ConversionFactor;
			}
			set
			{
				if ((this._ConversionFactor != value))
				{
					this._ConversionFactor = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UsdEquivalentAmount", DbType="Decimal(18,2)")]
		public System.Nullable<decimal> UsdEquivalentAmount
		{
			get
			{
				return this._UsdEquivalentAmount;
			}
			set
			{
				if ((this._UsdEquivalentAmount != value))
				{
					this._UsdEquivalentAmount = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SoftcashProgram", DbType="VarChar(200)")]
		public string SoftcashProgram
		{
			get
			{
				return this._SoftcashProgram;
			}
			set
			{
				if ((this._SoftcashProgram != value))
				{
					this._SoftcashProgram = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Timestamp", DbType="DateTime")]
		public System.Nullable<System.DateTime> Timestamp
		{
			get
			{
				return this._Timestamp;
			}
			set
			{
				if ((this._Timestamp != value))
				{
					this._Timestamp = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Reason", DbType="VarChar(1000)")]
		public string Reason
		{
			get
			{
				return this._Reason;
			}
			set
			{
				if ((this._Reason != value))
				{
					this._Reason = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Comment", DbType="VarChar(1000)")]
		public string Comment
		{
			get
			{
				return this._Comment;
			}
			set
			{
				if ((this._Comment != value))
				{
					this._Comment = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Validity", DbType="DateTime")]
		public System.Nullable<System.DateTime> Validity
		{
			get
			{
				return this._Validity;
			}
			set
			{
				if ((this._Validity != value))
				{
					this._Validity = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Availability", DbType="VarChar(9) NOT NULL", CanBeNull=false)]
		public string Availability
		{
			get
			{
				return this._Availability;
			}
			set
			{
				if ((this._Availability != value))
				{
					this._Availability = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TransactionStatus", DbType="VarChar(15) NOT NULL", CanBeNull=false)]
		public string TransactionStatus
		{
			get
			{
				return this._TransactionStatus;
			}
			set
			{
				if ((this._TransactionStatus != value))
				{
					this._TransactionStatus = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ClosingBalance", DbType="Decimal(38,2) NOT NULL")]
		public decimal ClosingBalance
		{
			get
			{
				return this._ClosingBalance;
			}
			set
			{
				if ((this._ClosingBalance != value))
				{
					this._ClosingBalance = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RequesterUserName", DbType="VarChar(1000)")]
		public string RequesterUserName
		{
			get
			{
				return this._RequesterUserName;
			}
			set
			{
				if ((this._RequesterUserName != value))
				{
					this._RequesterUserName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OrderId", DbType="VarChar(1000) NOT NULL", CanBeNull=false)]
		public string OrderId
		{
			get
			{
				return this._OrderId;
			}
			set
			{
				if ((this._OrderId != value))
				{
					this._OrderId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Application", DbType="VarChar(1000)")]
		public string Application
		{
			get
			{
				return this._Application;
			}
			set
			{
				if ((this._Application != value))
				{
					this._Application = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Username", DbType="VarChar(500)")]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				if ((this._Username != value))
				{
					this._Username = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
