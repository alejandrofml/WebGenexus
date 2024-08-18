/*
				   File: type_SdtSectorSDT_Collection
			Description: Collection
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
	[XmlRoot(ElementName="SectorSDT.Collection")]
	[XmlType(TypeName="SectorSDT.Collection" , Namespace="TallerGeneXus" )]
	[Serializable]
	public class SdtSectorSDT_Collection : GxUserType
	{
		public SdtSectorSDT_Collection( )
		{
			/* Constructor for serialization */
			gxTv_SdtSectorSDT_Collection_Sectornombre = "";

		}

		public SdtSectorSDT_Collection(IGxContext context)
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
			AddObjectProperty("SectorId", gxTpr_Sectorid, false);


			AddObjectProperty("SectorNombre", gxTpr_Sectornombre, false);


			AddObjectProperty("LugarId", gxTpr_Lugarid, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="SectorId")]
		[XmlElement(ElementName="SectorId")]
		public short gxTpr_Sectorid
		{
			get {
				return gxTv_SdtSectorSDT_Collection_Sectorid; 
			}
			set {
				gxTv_SdtSectorSDT_Collection_Sectorid = value;
				SetDirty("Sectorid");
			}
		}




		[SoapElement(ElementName="SectorNombre")]
		[XmlElement(ElementName="SectorNombre")]
		public string gxTpr_Sectornombre
		{
			get {
				return gxTv_SdtSectorSDT_Collection_Sectornombre; 
			}
			set {
				gxTv_SdtSectorSDT_Collection_Sectornombre = value;
				SetDirty("Sectornombre");
			}
		}




		[SoapElement(ElementName="LugarId")]
		[XmlElement(ElementName="LugarId")]
		public short gxTpr_Lugarid
		{
			get {
				return gxTv_SdtSectorSDT_Collection_Lugarid; 
			}
			set {
				gxTv_SdtSectorSDT_Collection_Lugarid = value;
				SetDirty("Lugarid");
			}
		}



		public override bool ShouldSerializeSdtJson()
		{
			return true;
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
			gxTv_SdtSectorSDT_Collection_Sectornombre = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtSectorSDT_Collection_Sectorid;
		 

		protected string gxTv_SdtSectorSDT_Collection_Sectornombre;
		 

		protected short gxTv_SdtSectorSDT_Collection_Lugarid;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SectorSDT.Collection", Namespace="TallerGeneXus")]
	public class SdtSectorSDT_Collection_RESTInterface : GxGenericCollectionItem<SdtSectorSDT_Collection>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSectorSDT_Collection_RESTInterface( ) : base()
		{	
		}

		public SdtSectorSDT_Collection_RESTInterface( SdtSectorSDT_Collection psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="SectorId", Order=0)]
		public short gxTpr_Sectorid
		{
			get { 
				return sdt.gxTpr_Sectorid;

			}
			set { 
				sdt.gxTpr_Sectorid = value;
			}
		}

		[DataMember(Name="SectorNombre", Order=1)]
		public  string gxTpr_Sectornombre
		{
			get { 
				return sdt.gxTpr_Sectornombre;

			}
			set { 
				 sdt.gxTpr_Sectornombre = value;
			}
		}

		[DataMember(Name="LugarId", Order=2)]
		public short gxTpr_Lugarid
		{
			get { 
				return sdt.gxTpr_Lugarid;

			}
			set { 
				sdt.gxTpr_Lugarid = value;
			}
		}


		#endregion

		public SdtSectorSDT_Collection sdt
		{
			get { 
				return (SdtSectorSDT_Collection)Sdt;
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
				sdt = new SdtSectorSDT_Collection() ;
			}
		}
	}
	#endregion
}