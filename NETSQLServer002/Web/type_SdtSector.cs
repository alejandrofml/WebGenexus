using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlRoot(ElementName = "Sector" )]
   [XmlType(TypeName =  "Sector" , Namespace = "TallerGeneXus" )]
   [Serializable]
   public class SdtSector : GxSilentTrnSdt
   {
      public SdtSector( )
      {
      }

      public SdtSector( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetEntryAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void Load( short AV5SectorId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV5SectorId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"SectorId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Sector");
         metadata.Set("BT", "Sector");
         metadata.Set("PK", "[ \"SectorId\" ]");
         metadata.Set("PKAssigned", "[ \"SectorId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"LugarId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Sectorid_Z");
         state.Add("gxTpr_Sectornombre_Z");
         state.Add("gxTpr_Sectorcapacidad_Z");
         state.Add("gxTpr_Sectorprecio_Z");
         state.Add("gxTpr_Lugarid_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtSector sdt;
         sdt = (SdtSector)(source);
         gxTv_SdtSector_Sectorid = sdt.gxTv_SdtSector_Sectorid ;
         gxTv_SdtSector_Sectornombre = sdt.gxTv_SdtSector_Sectornombre ;
         gxTv_SdtSector_Sectorcapacidad = sdt.gxTv_SdtSector_Sectorcapacidad ;
         gxTv_SdtSector_Sectorprecio = sdt.gxTv_SdtSector_Sectorprecio ;
         gxTv_SdtSector_Lugarid = sdt.gxTv_SdtSector_Lugarid ;
         gxTv_SdtSector_Mode = sdt.gxTv_SdtSector_Mode ;
         gxTv_SdtSector_Initialized = sdt.gxTv_SdtSector_Initialized ;
         gxTv_SdtSector_Sectorid_Z = sdt.gxTv_SdtSector_Sectorid_Z ;
         gxTv_SdtSector_Sectornombre_Z = sdt.gxTv_SdtSector_Sectornombre_Z ;
         gxTv_SdtSector_Sectorcapacidad_Z = sdt.gxTv_SdtSector_Sectorcapacidad_Z ;
         gxTv_SdtSector_Sectorprecio_Z = sdt.gxTv_SdtSector_Sectorprecio_Z ;
         gxTv_SdtSector_Lugarid_Z = sdt.gxTv_SdtSector_Lugarid_Z ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("SectorId", gxTv_SdtSector_Sectorid, false, includeNonInitialized);
         AddObjectProperty("SectorNombre", gxTv_SdtSector_Sectornombre, false, includeNonInitialized);
         AddObjectProperty("SectorCapacidad", gxTv_SdtSector_Sectorcapacidad, false, includeNonInitialized);
         AddObjectProperty("SectorPrecio", gxTv_SdtSector_Sectorprecio, false, includeNonInitialized);
         AddObjectProperty("LugarId", gxTv_SdtSector_Lugarid, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtSector_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtSector_Initialized, false, includeNonInitialized);
            AddObjectProperty("SectorId_Z", gxTv_SdtSector_Sectorid_Z, false, includeNonInitialized);
            AddObjectProperty("SectorNombre_Z", gxTv_SdtSector_Sectornombre_Z, false, includeNonInitialized);
            AddObjectProperty("SectorCapacidad_Z", gxTv_SdtSector_Sectorcapacidad_Z, false, includeNonInitialized);
            AddObjectProperty("SectorPrecio_Z", gxTv_SdtSector_Sectorprecio_Z, false, includeNonInitialized);
            AddObjectProperty("LugarId_Z", gxTv_SdtSector_Lugarid_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtSector sdt )
      {
         if ( sdt.IsDirty("SectorId") )
         {
            sdtIsNull = 0;
            gxTv_SdtSector_Sectorid = sdt.gxTv_SdtSector_Sectorid ;
         }
         if ( sdt.IsDirty("SectorNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtSector_Sectornombre = sdt.gxTv_SdtSector_Sectornombre ;
         }
         if ( sdt.IsDirty("SectorCapacidad") )
         {
            sdtIsNull = 0;
            gxTv_SdtSector_Sectorcapacidad = sdt.gxTv_SdtSector_Sectorcapacidad ;
         }
         if ( sdt.IsDirty("SectorPrecio") )
         {
            sdtIsNull = 0;
            gxTv_SdtSector_Sectorprecio = sdt.gxTv_SdtSector_Sectorprecio ;
         }
         if ( sdt.IsDirty("LugarId") )
         {
            sdtIsNull = 0;
            gxTv_SdtSector_Lugarid = sdt.gxTv_SdtSector_Lugarid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "SectorId" )]
      [  XmlElement( ElementName = "SectorId"   )]
      public short gxTpr_Sectorid
      {
         get {
            return gxTv_SdtSector_Sectorid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtSector_Sectorid != value )
            {
               gxTv_SdtSector_Mode = "INS";
               this.gxTv_SdtSector_Sectorid_Z_SetNull( );
               this.gxTv_SdtSector_Sectornombre_Z_SetNull( );
               this.gxTv_SdtSector_Sectorcapacidad_Z_SetNull( );
               this.gxTv_SdtSector_Sectorprecio_Z_SetNull( );
               this.gxTv_SdtSector_Lugarid_Z_SetNull( );
            }
            gxTv_SdtSector_Sectorid = value;
            SetDirty("Sectorid");
         }

      }

      [  SoapElement( ElementName = "SectorNombre" )]
      [  XmlElement( ElementName = "SectorNombre"   )]
      public string gxTpr_Sectornombre
      {
         get {
            return gxTv_SdtSector_Sectornombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSector_Sectornombre = value;
            SetDirty("Sectornombre");
         }

      }

      [  SoapElement( ElementName = "SectorCapacidad" )]
      [  XmlElement( ElementName = "SectorCapacidad"   )]
      public short gxTpr_Sectorcapacidad
      {
         get {
            return gxTv_SdtSector_Sectorcapacidad ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSector_Sectorcapacidad = value;
            SetDirty("Sectorcapacidad");
         }

      }

      [  SoapElement( ElementName = "SectorPrecio" )]
      [  XmlElement( ElementName = "SectorPrecio"   )]
      public short gxTpr_Sectorprecio
      {
         get {
            return gxTv_SdtSector_Sectorprecio ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSector_Sectorprecio = value;
            SetDirty("Sectorprecio");
         }

      }

      [  SoapElement( ElementName = "LugarId" )]
      [  XmlElement( ElementName = "LugarId"   )]
      public short gxTpr_Lugarid
      {
         get {
            return gxTv_SdtSector_Lugarid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSector_Lugarid = value;
            SetDirty("Lugarid");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtSector_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSector_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtSector_Mode_SetNull( )
      {
         gxTv_SdtSector_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtSector_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtSector_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSector_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtSector_Initialized_SetNull( )
      {
         gxTv_SdtSector_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtSector_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SectorId_Z" )]
      [  XmlElement( ElementName = "SectorId_Z"   )]
      public short gxTpr_Sectorid_Z
      {
         get {
            return gxTv_SdtSector_Sectorid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSector_Sectorid_Z = value;
            SetDirty("Sectorid_Z");
         }

      }

      public void gxTv_SdtSector_Sectorid_Z_SetNull( )
      {
         gxTv_SdtSector_Sectorid_Z = 0;
         SetDirty("Sectorid_Z");
         return  ;
      }

      public bool gxTv_SdtSector_Sectorid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SectorNombre_Z" )]
      [  XmlElement( ElementName = "SectorNombre_Z"   )]
      public string gxTpr_Sectornombre_Z
      {
         get {
            return gxTv_SdtSector_Sectornombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSector_Sectornombre_Z = value;
            SetDirty("Sectornombre_Z");
         }

      }

      public void gxTv_SdtSector_Sectornombre_Z_SetNull( )
      {
         gxTv_SdtSector_Sectornombre_Z = "";
         SetDirty("Sectornombre_Z");
         return  ;
      }

      public bool gxTv_SdtSector_Sectornombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SectorCapacidad_Z" )]
      [  XmlElement( ElementName = "SectorCapacidad_Z"   )]
      public short gxTpr_Sectorcapacidad_Z
      {
         get {
            return gxTv_SdtSector_Sectorcapacidad_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSector_Sectorcapacidad_Z = value;
            SetDirty("Sectorcapacidad_Z");
         }

      }

      public void gxTv_SdtSector_Sectorcapacidad_Z_SetNull( )
      {
         gxTv_SdtSector_Sectorcapacidad_Z = 0;
         SetDirty("Sectorcapacidad_Z");
         return  ;
      }

      public bool gxTv_SdtSector_Sectorcapacidad_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SectorPrecio_Z" )]
      [  XmlElement( ElementName = "SectorPrecio_Z"   )]
      public short gxTpr_Sectorprecio_Z
      {
         get {
            return gxTv_SdtSector_Sectorprecio_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSector_Sectorprecio_Z = value;
            SetDirty("Sectorprecio_Z");
         }

      }

      public void gxTv_SdtSector_Sectorprecio_Z_SetNull( )
      {
         gxTv_SdtSector_Sectorprecio_Z = 0;
         SetDirty("Sectorprecio_Z");
         return  ;
      }

      public bool gxTv_SdtSector_Sectorprecio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LugarId_Z" )]
      [  XmlElement( ElementName = "LugarId_Z"   )]
      public short gxTpr_Lugarid_Z
      {
         get {
            return gxTv_SdtSector_Lugarid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSector_Lugarid_Z = value;
            SetDirty("Lugarid_Z");
         }

      }

      public void gxTv_SdtSector_Lugarid_Z_SetNull( )
      {
         gxTv_SdtSector_Lugarid_Z = 0;
         SetDirty("Lugarid_Z");
         return  ;
      }

      public bool gxTv_SdtSector_Lugarid_Z_IsNull( )
      {
         return false ;
      }

      [XmlIgnore]
      private static GXTypeInfo _typeProps;
      protected override GXTypeInfo TypeInfo
      {
         get {
            return _typeProps ;
         }

         set {
            _typeProps = value ;
         }

      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_SdtSector_Sectornombre = "";
         gxTv_SdtSector_Mode = "";
         gxTv_SdtSector_Sectornombre_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "sector", "GeneXus.Programs.sector_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short gxTv_SdtSector_Sectorid ;
      private short sdtIsNull ;
      private short gxTv_SdtSector_Sectorcapacidad ;
      private short gxTv_SdtSector_Sectorprecio ;
      private short gxTv_SdtSector_Lugarid ;
      private short gxTv_SdtSector_Initialized ;
      private short gxTv_SdtSector_Sectorid_Z ;
      private short gxTv_SdtSector_Sectorcapacidad_Z ;
      private short gxTv_SdtSector_Sectorprecio_Z ;
      private short gxTv_SdtSector_Lugarid_Z ;
      private string gxTv_SdtSector_Mode ;
      private string gxTv_SdtSector_Sectornombre ;
      private string gxTv_SdtSector_Sectornombre_Z ;
   }

   [DataContract(Name = @"Sector", Namespace = "TallerGeneXus")]
   [GxJsonSerialization("default")]
   public class SdtSector_RESTInterface : GxGenericCollectionItem<SdtSector>
   {
      public SdtSector_RESTInterface( ) : base()
      {
      }

      public SdtSector_RESTInterface( SdtSector psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SectorId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Sectorid
      {
         get {
            return sdt.gxTpr_Sectorid ;
         }

         set {
            sdt.gxTpr_Sectorid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "SectorNombre" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Sectornombre
      {
         get {
            return sdt.gxTpr_Sectornombre ;
         }

         set {
            sdt.gxTpr_Sectornombre = value;
         }

      }

      [DataMember( Name = "SectorCapacidad" , Order = 2 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Sectorcapacidad
      {
         get {
            return sdt.gxTpr_Sectorcapacidad ;
         }

         set {
            sdt.gxTpr_Sectorcapacidad = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "SectorPrecio" , Order = 3 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Sectorprecio
      {
         get {
            return sdt.gxTpr_Sectorprecio ;
         }

         set {
            sdt.gxTpr_Sectorprecio = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "LugarId" , Order = 4 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Lugarid
      {
         get {
            return sdt.gxTpr_Lugarid ;
         }

         set {
            sdt.gxTpr_Lugarid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtSector sdt
      {
         get {
            return (SdtSector)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtSector() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 5 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"Sector", Namespace = "TallerGeneXus")]
   [GxJsonSerialization("default")]
   public class SdtSector_RESTLInterface : GxGenericCollectionItem<SdtSector>
   {
      public SdtSector_RESTLInterface( ) : base()
      {
      }

      public SdtSector_RESTLInterface( SdtSector psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SectorNombre" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Sectornombre
      {
         get {
            return sdt.gxTpr_Sectornombre ;
         }

         set {
            sdt.gxTpr_Sectornombre = value;
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtSector sdt
      {
         get {
            return (SdtSector)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtSector() ;
         }
      }

   }

}
