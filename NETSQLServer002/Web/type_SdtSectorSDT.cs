/*
				   File: type_SdtSectorSDT
			Description: SectorSDT
				 Author: Nemo 🐠 for C# (.NET) version 18.0.10.184260
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;


namespace GeneXus.Programs
{
	[XmlRoot(ElementName="SectorSDT")]
	[XmlType(TypeName="SectorSDT" , Namespace="TallerGeneXus" )]
	[Serializable]
	public class SdtSectorSDT : GxUserType
	{
		public SdtSectorSDT( )
		{
			/* Constructor for serialization */
		}

		public SdtSectorSDT(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			if (gxTv_SdtSectorSDT_Collection != null)
			{
				AddObjectProperty("Collection", gxTv_SdtSectorSDT_Collection, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Collection" )]
		[XmlElement(ElementName="Collection" )]
		public SdtSectorSDT_Collection gxTpr_Collection
		{
			get {
				if ( gxTv_SdtSectorSDT_Collection == null )
				{
					gxTv_SdtSectorSDT_Collection = new SdtSectorSDT_Collection(context);
				}
				gxTv_SdtSectorSDT_Collection_N = false;
				return gxTv_SdtSectorSDT_Collection;
			}
			set {
				gxTv_SdtSectorSDT_Collection_N = false;
				gxTv_SdtSectorSDT_Collection = value;
				SetDirty("Collection");
			}

		}

		public void gxTv_SdtSectorSDT_Collection_SetNull()
		{
			gxTv_SdtSectorSDT_Collection_N = true;
			gxTv_SdtSectorSDT_Collection = null;
		}

		public bool gxTv_SdtSectorSDT_Collection_IsNull()
		{
			return gxTv_SdtSectorSDT_Collection == null;
		}
		public bool ShouldSerializegxTpr_Collection_Json()
		{
				return (gxTv_SdtSectorSDT_Collection != null && gxTv_SdtSectorSDT_Collection.ShouldSerializeSdtJson());

		}


		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Collection_Json() || 
				false);
		}



		#endregion

		#region Static Type Properties

		[XmlIgnore]
		private static GXTypeInfo _typeProps;
		protected override GXTypeInfo TypeInfo { get { return _typeProps; } set { _typeProps = value; } }

		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtSectorSDT_Collection_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtSectorSDT_Collection_N;
		protected SdtSectorSDT_Collection gxTv_SdtSectorSDT_Collection = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SectorSDT", Namespace="TallerGeneXus")]
	public class SdtSectorSDT_RESTInterface : GxGenericCollectionItem<SdtSectorSDT>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSectorSDT_RESTInterface( ) : base()
		{	
		}

		public SdtSectorSDT_RESTInterface( SdtSectorSDT psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Collection", Order=0, EmitDefaultValue=false)]
		public SdtSectorSDT_Collection_RESTInterface gxTpr_Collection
		{
			get {
				if (sdt.ShouldSerializegxTpr_Collection_Json())
					return new SdtSectorSDT_Collection_RESTInterface(sdt.gxTpr_Collection);
				else
					return null;

			}

			set {
				sdt.gxTpr_Collection = value.sdt;
			}

		}


		#endregion

		public SdtSectorSDT sdt
		{
			get { 
				return (SdtSectorSDT)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtSectorSDT() ;
			}
		}
	}
	#endregion
}