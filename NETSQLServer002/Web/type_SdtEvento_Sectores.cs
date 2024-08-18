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
   [XmlRoot(ElementName = "Evento.Sectores" )]
   [XmlType(TypeName =  "Evento.Sectores" , Namespace = "TallerGeneXus" )]
   [Serializable]
   public class SdtEvento_Sectores : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtEvento_Sectores( )
      {
      }

      public SdtEvento_Sectores( IGxContext context )
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

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"SectorId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Sectores");
         metadata.Set("BT", "EventoSector");
         metadata.Set("PK", "[ \"SectorId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"EventoId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"SectorId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Modified");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Sectorid_Z");
         state.Add("gxTpr_Sectornombre_Z");
         state.Add("gxTpr_Sectorcapacidad_Z");
         state.Add("gxTpr_Sectorprecio_Z");
         state.Add("gxTpr_Sectorcupoactual_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtEvento_Sectores sdt;
         sdt = (SdtEvento_Sectores)(source);
         gxTv_SdtEvento_Sectores_Sectorid = sdt.gxTv_SdtEvento_Sectores_Sectorid ;
         gxTv_SdtEvento_Sectores_Sectornombre = sdt.gxTv_SdtEvento_Sectores_Sectornombre ;
         gxTv_SdtEvento_Sectores_Sectorcapacidad = sdt.gxTv_SdtEvento_Sectores_Sectorcapacidad ;
         gxTv_SdtEvento_Sectores_Sectorprecio = sdt.gxTv_SdtEvento_Sectores_Sectorprecio ;
         gxTv_SdtEvento_Sectores_Sectorcupoactual = sdt.gxTv_SdtEvento_Sectores_Sectorcupoactual ;
         gxTv_SdtEvento_Sectores_Mode = sdt.gxTv_SdtEvento_Sectores_Mode ;
         gxTv_SdtEvento_Sectores_Modified = sdt.gxTv_SdtEvento_Sectores_Modified ;
         gxTv_SdtEvento_Sectores_Initialized = sdt.gxTv_SdtEvento_Sectores_Initialized ;
         gxTv_SdtEvento_Sectores_Sectorid_Z = sdt.gxTv_SdtEvento_Sectores_Sectorid_Z ;
         gxTv_SdtEvento_Sectores_Sectornombre_Z = sdt.gxTv_SdtEvento_Sectores_Sectornombre_Z ;
         gxTv_SdtEvento_Sectores_Sectorcapacidad_Z = sdt.gxTv_SdtEvento_Sectores_Sectorcapacidad_Z ;
         gxTv_SdtEvento_Sectores_Sectorprecio_Z = sdt.gxTv_SdtEvento_Sectores_Sectorprecio_Z ;
         gxTv_SdtEvento_Sectores_Sectorcupoactual_Z = sdt.gxTv_SdtEvento_Sectores_Sectorcupoactual_Z ;
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
         AddObjectProperty("SectorId", gxTv_SdtEvento_Sectores_Sectorid, false, includeNonInitialized);
         AddObjectProperty("SectorNombre", gxTv_SdtEvento_Sectores_Sectornombre, false, includeNonInitialized);
         AddObjectProperty("SectorCapacidad", gxTv_SdtEvento_Sectores_Sectorcapacidad, false, includeNonInitialized);
         AddObjectProperty("SectorPrecio", gxTv_SdtEvento_Sectores_Sectorprecio, false, includeNonInitialized);
         AddObjectProperty("SectorCupoActual", gxTv_SdtEvento_Sectores_Sectorcupoactual, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtEvento_Sectores_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtEvento_Sectores_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtEvento_Sectores_Initialized, false, includeNonInitialized);
            AddObjectProperty("SectorId_Z", gxTv_SdtEvento_Sectores_Sectorid_Z, false, includeNonInitialized);
            AddObjectProperty("SectorNombre_Z", gxTv_SdtEvento_Sectores_Sectornombre_Z, false, includeNonInitialized);
            AddObjectProperty("SectorCapacidad_Z", gxTv_SdtEvento_Sectores_Sectorcapacidad_Z, false, includeNonInitialized);
            AddObjectProperty("SectorPrecio_Z", gxTv_SdtEvento_Sectores_Sectorprecio_Z, false, includeNonInitialized);
            AddObjectProperty("SectorCupoActual_Z", gxTv_SdtEvento_Sectores_Sectorcupoactual_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtEvento_Sectores sdt )
      {
         if ( sdt.IsDirty("SectorId") )
         {
            sdtIsNull = 0;
            gxTv_SdtEvento_Sectores_Sectorid = sdt.gxTv_SdtEvento_Sectores_Sectorid ;
         }
         if ( sdt.IsDirty("SectorNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtEvento_Sectores_Sectornombre = sdt.gxTv_SdtEvento_Sectores_Sectornombre ;
         }
         if ( sdt.IsDirty("SectorCapacidad") )
         {
            sdtIsNull = 0;
            gxTv_SdtEvento_Sectores_Sectorcapacidad = sdt.gxTv_SdtEvento_Sectores_Sectorcapacidad ;
         }
         if ( sdt.IsDirty("SectorPrecio") )
         {
            sdtIsNull = 0;
            gxTv_SdtEvento_Sectores_Sectorprecio = sdt.gxTv_SdtEvento_Sectores_Sectorprecio ;
         }
         if ( sdt.IsDirty("SectorCupoActual") )
         {
            sdtIsNull = 0;
            gxTv_SdtEvento_Sectores_Sectorcupoactual = sdt.gxTv_SdtEvento_Sectores_Sectorcupoactual ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "SectorId" )]
      [  XmlElement( ElementName = "SectorId"   )]
      public short gxTpr_Sectorid
      {
         get {
            return gxTv_SdtEvento_Sectores_Sectorid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEvento_Sectores_Sectorid = value;
            gxTv_SdtEvento_Sectores_Modified = 1;
            SetDirty("Sectorid");
         }

      }

      [  SoapElement( ElementName = "SectorNombre" )]
      [  XmlElement( ElementName = "SectorNombre"   )]
      public string gxTpr_Sectornombre
      {
         get {
            return gxTv_SdtEvento_Sectores_Sectornombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEvento_Sectores_Sectornombre = value;
            gxTv_SdtEvento_Sectores_Modified = 1;
            SetDirty("Sectornombre");
         }

      }

      [  SoapElement( ElementName = "SectorCapacidad" )]
      [  XmlElement( ElementName = "SectorCapacidad"   )]
      public short gxTpr_Sectorcapacidad
      {
         get {
            return gxTv_SdtEvento_Sectores_Sectorcapacidad ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEvento_Sectores_Sectorcapacidad = value;
            gxTv_SdtEvento_Sectores_Modified = 1;
            SetDirty("Sectorcapacidad");
         }

      }

      [  SoapElement( ElementName = "SectorPrecio" )]
      [  XmlElement( ElementName = "SectorPrecio"   )]
      public short gxTpr_Sectorprecio
      {
         get {
            return gxTv_SdtEvento_Sectores_Sectorprecio ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEvento_Sectores_Sectorprecio = value;
            gxTv_SdtEvento_Sectores_Modified = 1;
            SetDirty("Sectorprecio");
         }

      }

      [  SoapElement( ElementName = "SectorCupoActual" )]
      [  XmlElement( ElementName = "SectorCupoActual"   )]
      public short gxTpr_Sectorcupoactual
      {
         get {
            return gxTv_SdtEvento_Sectores_Sectorcupoactual ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEvento_Sectores_Sectorcupoactual = value;
            gxTv_SdtEvento_Sectores_Modified = 1;
            SetDirty("Sectorcupoactual");
         }

      }

      public void gxTv_SdtEvento_Sectores_Sectorcupoactual_SetNull( )
      {
         gxTv_SdtEvento_Sectores_Sectorcupoactual = 0;
         SetDirty("Sectorcupoactual");
         return  ;
      }

      public bool gxTv_SdtEvento_Sectores_Sectorcupoactual_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtEvento_Sectores_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEvento_Sectores_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtEvento_Sectores_Mode_SetNull( )
      {
         gxTv_SdtEvento_Sectores_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtEvento_Sectores_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtEvento_Sectores_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEvento_Sectores_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtEvento_Sectores_Modified_SetNull( )
      {
         gxTv_SdtEvento_Sectores_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtEvento_Sectores_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtEvento_Sectores_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEvento_Sectores_Initialized = value;
            gxTv_SdtEvento_Sectores_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtEvento_Sectores_Initialized_SetNull( )
      {
         gxTv_SdtEvento_Sectores_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtEvento_Sectores_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SectorId_Z" )]
      [  XmlElement( ElementName = "SectorId_Z"   )]
      public short gxTpr_Sectorid_Z
      {
         get {
            return gxTv_SdtEvento_Sectores_Sectorid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEvento_Sectores_Sectorid_Z = value;
            gxTv_SdtEvento_Sectores_Modified = 1;
            SetDirty("Sectorid_Z");
         }

      }

      public void gxTv_SdtEvento_Sectores_Sectorid_Z_SetNull( )
      {
         gxTv_SdtEvento_Sectores_Sectorid_Z = 0;
         SetDirty("Sectorid_Z");
         return  ;
      }

      public bool gxTv_SdtEvento_Sectores_Sectorid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SectorNombre_Z" )]
      [  XmlElement( ElementName = "SectorNombre_Z"   )]
      public string gxTpr_Sectornombre_Z
      {
         get {
            return gxTv_SdtEvento_Sectores_Sectornombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEvento_Sectores_Sectornombre_Z = value;
            gxTv_SdtEvento_Sectores_Modified = 1;
            SetDirty("Sectornombre_Z");
         }

      }

      public void gxTv_SdtEvento_Sectores_Sectornombre_Z_SetNull( )
      {
         gxTv_SdtEvento_Sectores_Sectornombre_Z = "";
         SetDirty("Sectornombre_Z");
         return  ;
      }

      public bool gxTv_SdtEvento_Sectores_Sectornombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SectorCapacidad_Z" )]
      [  XmlElement( ElementName = "SectorCapacidad_Z"   )]
      public short gxTpr_Sectorcapacidad_Z
      {
         get {
            return gxTv_SdtEvento_Sectores_Sectorcapacidad_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEvento_Sectores_Sectorcapacidad_Z = value;
            gxTv_SdtEvento_Sectores_Modified = 1;
            SetDirty("Sectorcapacidad_Z");
         }

      }

      public void gxTv_SdtEvento_Sectores_Sectorcapacidad_Z_SetNull( )
      {
         gxTv_SdtEvento_Sectores_Sectorcapacidad_Z = 0;
         SetDirty("Sectorcapacidad_Z");
         return  ;
      }

      public bool gxTv_SdtEvento_Sectores_Sectorcapacidad_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SectorPrecio_Z" )]
      [  XmlElement( ElementName = "SectorPrecio_Z"   )]
      public short gxTpr_Sectorprecio_Z
      {
         get {
            return gxTv_SdtEvento_Sectores_Sectorprecio_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEvento_Sectores_Sectorprecio_Z = value;
            gxTv_SdtEvento_Sectores_Modified = 1;
            SetDirty("Sectorprecio_Z");
         }

      }

      public void gxTv_SdtEvento_Sectores_Sectorprecio_Z_SetNull( )
      {
         gxTv_SdtEvento_Sectores_Sectorprecio_Z = 0;
         SetDirty("Sectorprecio_Z");
         return  ;
      }

      public bool gxTv_SdtEvento_Sectores_Sectorprecio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SectorCupoActual_Z" )]
      [  XmlElement( ElementName = "SectorCupoActual_Z"   )]
      public short gxTpr_Sectorcupoactual_Z
      {
         get {
            return gxTv_SdtEvento_Sectores_Sectorcupoactual_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEvento_Sectores_Sectorcupoactual_Z = value;
            gxTv_SdtEvento_Sectores_Modified = 1;
            SetDirty("Sectorcupoactual_Z");
         }

      }

      public void gxTv_SdtEvento_Sectores_Sectorcupoactual_Z_SetNull( )
      {
         gxTv_SdtEvento_Sectores_Sectorcupoactual_Z = 0;
         SetDirty("Sectorcupoactual_Z");
         return  ;
      }

      public bool gxTv_SdtEvento_Sectores_Sectorcupoactual_Z_IsNull( )
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
         gxTv_SdtEvento_Sectores_Sectornombre = "";
         gxTv_SdtEvento_Sectores_Mode = "";
         gxTv_SdtEvento_Sectores_Sectornombre_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short gxTv_SdtEvento_Sectores_Sectorid ;
      private short sdtIsNull ;
      private short gxTv_SdtEvento_Sectores_Sectorcapacidad ;
      private short gxTv_SdtEvento_Sectores_Sectorprecio ;
      private short gxTv_SdtEvento_Sectores_Sectorcupoactual ;
      private short gxTv_SdtEvento_Sectores_Modified ;
      private short gxTv_SdtEvento_Sectores_Initialized ;
      private short gxTv_SdtEvento_Sectores_Sectorid_Z ;
      private short gxTv_SdtEvento_Sectores_Sectorcapacidad_Z ;
      private short gxTv_SdtEvento_Sectores_Sectorprecio_Z ;
      private short gxTv_SdtEvento_Sectores_Sectorcupoactual_Z ;
      private string gxTv_SdtEvento_Sectores_Mode ;
      private string gxTv_SdtEvento_Sectores_Sectornombre ;
      private string gxTv_SdtEvento_Sectores_Sectornombre_Z ;
   }

   [DataContract(Name = @"Evento.Sectores", Namespace = "TallerGeneXus")]
   [GxJsonSerialization("default")]
   public class SdtEvento_Sectores_RESTInterface : GxGenericCollectionItem<SdtEvento_Sectores>
   {
      public SdtEvento_Sectores_RESTInterface( ) : base()
      {
      }

      public SdtEvento_Sectores_RESTInterface( SdtEvento_Sectores psdt ) : base(psdt)
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

      [DataMember( Name = "SectorCupoActual" , Order = 4 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Sectorcupoactual
      {
         get {
            return sdt.gxTpr_Sectorcupoactual ;
         }

         set {
            sdt.gxTpr_Sectorcupoactual = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtEvento_Sectores sdt
      {
         get {
            return (SdtEvento_Sectores)Sdt ;
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
            sdt = new SdtEvento_Sectores() ;
         }
      }

   }

   [DataContract(Name = @"Evento.Sectores", Namespace = "TallerGeneXus")]
   [GxJsonSerialization("default")]
   public class SdtEvento_Sectores_RESTLInterface : GxGenericCollectionItem<SdtEvento_Sectores>
   {
      public SdtEvento_Sectores_RESTLInterface( ) : base()
      {
      }

      public SdtEvento_Sectores_RESTLInterface( SdtEvento_Sectores psdt ) : base(psdt)
      {
      }

      public SdtEvento_Sectores sdt
      {
         get {
            return (SdtEvento_Sectores)Sdt ;
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
            sdt = new SdtEvento_Sectores() ;
         }
      }

   }

}
