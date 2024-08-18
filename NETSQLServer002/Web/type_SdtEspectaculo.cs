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
   [XmlRoot(ElementName = "Espectaculo" )]
   [XmlType(TypeName =  "Espectaculo" , Namespace = "TallerGeneXus" )]
   [Serializable]
   public class SdtEspectaculo : GxSilentTrnSdt
   {
      public SdtEspectaculo( )
      {
      }

      public SdtEspectaculo( IGxContext context )
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

      public void Load( short AV1EspectaculoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV1EspectaculoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"EspectaculoId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Espectaculo");
         metadata.Set("BT", "Espectaculo");
         metadata.Set("PK", "[ \"EspectaculoId\" ]");
         metadata.Set("PKAssigned", "[ \"EspectaculoId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"TipoEspectaculoId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Espectaculoimagen_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Espectaculoid_Z");
         state.Add("gxTpr_Espectaculonombre_Z");
         state.Add("gxTpr_Espectaculodescripcion_Z");
         state.Add("gxTpr_Tipoespectaculoid_Z");
         state.Add("gxTpr_Espectaculoimagen_gxi_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtEspectaculo sdt;
         sdt = (SdtEspectaculo)(source);
         gxTv_SdtEspectaculo_Espectaculoid = sdt.gxTv_SdtEspectaculo_Espectaculoid ;
         gxTv_SdtEspectaculo_Espectaculonombre = sdt.gxTv_SdtEspectaculo_Espectaculonombre ;
         gxTv_SdtEspectaculo_Espectaculodescripcion = sdt.gxTv_SdtEspectaculo_Espectaculodescripcion ;
         gxTv_SdtEspectaculo_Espectaculoimagen = sdt.gxTv_SdtEspectaculo_Espectaculoimagen ;
         gxTv_SdtEspectaculo_Espectaculoimagen_gxi = sdt.gxTv_SdtEspectaculo_Espectaculoimagen_gxi ;
         gxTv_SdtEspectaculo_Tipoespectaculoid = sdt.gxTv_SdtEspectaculo_Tipoespectaculoid ;
         gxTv_SdtEspectaculo_Mode = sdt.gxTv_SdtEspectaculo_Mode ;
         gxTv_SdtEspectaculo_Initialized = sdt.gxTv_SdtEspectaculo_Initialized ;
         gxTv_SdtEspectaculo_Espectaculoid_Z = sdt.gxTv_SdtEspectaculo_Espectaculoid_Z ;
         gxTv_SdtEspectaculo_Espectaculonombre_Z = sdt.gxTv_SdtEspectaculo_Espectaculonombre_Z ;
         gxTv_SdtEspectaculo_Espectaculodescripcion_Z = sdt.gxTv_SdtEspectaculo_Espectaculodescripcion_Z ;
         gxTv_SdtEspectaculo_Tipoespectaculoid_Z = sdt.gxTv_SdtEspectaculo_Tipoespectaculoid_Z ;
         gxTv_SdtEspectaculo_Espectaculoimagen_gxi_Z = sdt.gxTv_SdtEspectaculo_Espectaculoimagen_gxi_Z ;
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
         AddObjectProperty("EspectaculoId", gxTv_SdtEspectaculo_Espectaculoid, false, includeNonInitialized);
         AddObjectProperty("EspectaculoNombre", gxTv_SdtEspectaculo_Espectaculonombre, false, includeNonInitialized);
         AddObjectProperty("EspectaculoDescripcion", gxTv_SdtEspectaculo_Espectaculodescripcion, false, includeNonInitialized);
         AddObjectProperty("EspectaculoImagen", gxTv_SdtEspectaculo_Espectaculoimagen, false, includeNonInitialized);
         AddObjectProperty("TipoEspectaculoId", gxTv_SdtEspectaculo_Tipoespectaculoid, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("EspectaculoImagen_GXI", gxTv_SdtEspectaculo_Espectaculoimagen_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtEspectaculo_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtEspectaculo_Initialized, false, includeNonInitialized);
            AddObjectProperty("EspectaculoId_Z", gxTv_SdtEspectaculo_Espectaculoid_Z, false, includeNonInitialized);
            AddObjectProperty("EspectaculoNombre_Z", gxTv_SdtEspectaculo_Espectaculonombre_Z, false, includeNonInitialized);
            AddObjectProperty("EspectaculoDescripcion_Z", gxTv_SdtEspectaculo_Espectaculodescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("TipoEspectaculoId_Z", gxTv_SdtEspectaculo_Tipoespectaculoid_Z, false, includeNonInitialized);
            AddObjectProperty("EspectaculoImagen_GXI_Z", gxTv_SdtEspectaculo_Espectaculoimagen_gxi_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtEspectaculo sdt )
      {
         if ( sdt.IsDirty("EspectaculoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtEspectaculo_Espectaculoid = sdt.gxTv_SdtEspectaculo_Espectaculoid ;
         }
         if ( sdt.IsDirty("EspectaculoNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtEspectaculo_Espectaculonombre = sdt.gxTv_SdtEspectaculo_Espectaculonombre ;
         }
         if ( sdt.IsDirty("EspectaculoDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtEspectaculo_Espectaculodescripcion = sdt.gxTv_SdtEspectaculo_Espectaculodescripcion ;
         }
         if ( sdt.IsDirty("EspectaculoImagen") )
         {
            sdtIsNull = 0;
            gxTv_SdtEspectaculo_Espectaculoimagen = sdt.gxTv_SdtEspectaculo_Espectaculoimagen ;
         }
         if ( sdt.IsDirty("EspectaculoImagen") )
         {
            sdtIsNull = 0;
            gxTv_SdtEspectaculo_Espectaculoimagen_gxi = sdt.gxTv_SdtEspectaculo_Espectaculoimagen_gxi ;
         }
         if ( sdt.IsDirty("TipoEspectaculoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtEspectaculo_Tipoespectaculoid = sdt.gxTv_SdtEspectaculo_Tipoespectaculoid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "EspectaculoId" )]
      [  XmlElement( ElementName = "EspectaculoId"   )]
      public short gxTpr_Espectaculoid
      {
         get {
            return gxTv_SdtEspectaculo_Espectaculoid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtEspectaculo_Espectaculoid != value )
            {
               gxTv_SdtEspectaculo_Mode = "INS";
               this.gxTv_SdtEspectaculo_Espectaculoid_Z_SetNull( );
               this.gxTv_SdtEspectaculo_Espectaculonombre_Z_SetNull( );
               this.gxTv_SdtEspectaculo_Espectaculodescripcion_Z_SetNull( );
               this.gxTv_SdtEspectaculo_Tipoespectaculoid_Z_SetNull( );
               this.gxTv_SdtEspectaculo_Espectaculoimagen_gxi_Z_SetNull( );
            }
            gxTv_SdtEspectaculo_Espectaculoid = value;
            SetDirty("Espectaculoid");
         }

      }

      [  SoapElement( ElementName = "EspectaculoNombre" )]
      [  XmlElement( ElementName = "EspectaculoNombre"   )]
      public string gxTpr_Espectaculonombre
      {
         get {
            return gxTv_SdtEspectaculo_Espectaculonombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEspectaculo_Espectaculonombre = value;
            SetDirty("Espectaculonombre");
         }

      }

      [  SoapElement( ElementName = "EspectaculoDescripcion" )]
      [  XmlElement( ElementName = "EspectaculoDescripcion"   )]
      public string gxTpr_Espectaculodescripcion
      {
         get {
            return gxTv_SdtEspectaculo_Espectaculodescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEspectaculo_Espectaculodescripcion = value;
            SetDirty("Espectaculodescripcion");
         }

      }

      [  SoapElement( ElementName = "EspectaculoImagen" )]
      [  XmlElement( ElementName = "EspectaculoImagen"   )]
      [GxUpload()]
      public string gxTpr_Espectaculoimagen
      {
         get {
            return gxTv_SdtEspectaculo_Espectaculoimagen ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEspectaculo_Espectaculoimagen = value;
            SetDirty("Espectaculoimagen");
         }

      }

      [  SoapElement( ElementName = "EspectaculoImagen_GXI" )]
      [  XmlElement( ElementName = "EspectaculoImagen_GXI"   )]
      public string gxTpr_Espectaculoimagen_gxi
      {
         get {
            return gxTv_SdtEspectaculo_Espectaculoimagen_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEspectaculo_Espectaculoimagen_gxi = value;
            SetDirty("Espectaculoimagen_gxi");
         }

      }

      [  SoapElement( ElementName = "TipoEspectaculoId" )]
      [  XmlElement( ElementName = "TipoEspectaculoId"   )]
      public short gxTpr_Tipoespectaculoid
      {
         get {
            return gxTv_SdtEspectaculo_Tipoespectaculoid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEspectaculo_Tipoespectaculoid = value;
            SetDirty("Tipoespectaculoid");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtEspectaculo_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEspectaculo_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtEspectaculo_Mode_SetNull( )
      {
         gxTv_SdtEspectaculo_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtEspectaculo_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEspectaculo_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtEspectaculo_Initialized_SetNull( )
      {
         gxTv_SdtEspectaculo_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspectaculoId_Z" )]
      [  XmlElement( ElementName = "EspectaculoId_Z"   )]
      public short gxTpr_Espectaculoid_Z
      {
         get {
            return gxTv_SdtEspectaculo_Espectaculoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEspectaculo_Espectaculoid_Z = value;
            SetDirty("Espectaculoid_Z");
         }

      }

      public void gxTv_SdtEspectaculo_Espectaculoid_Z_SetNull( )
      {
         gxTv_SdtEspectaculo_Espectaculoid_Z = 0;
         SetDirty("Espectaculoid_Z");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_Espectaculoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspectaculoNombre_Z" )]
      [  XmlElement( ElementName = "EspectaculoNombre_Z"   )]
      public string gxTpr_Espectaculonombre_Z
      {
         get {
            return gxTv_SdtEspectaculo_Espectaculonombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEspectaculo_Espectaculonombre_Z = value;
            SetDirty("Espectaculonombre_Z");
         }

      }

      public void gxTv_SdtEspectaculo_Espectaculonombre_Z_SetNull( )
      {
         gxTv_SdtEspectaculo_Espectaculonombre_Z = "";
         SetDirty("Espectaculonombre_Z");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_Espectaculonombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspectaculoDescripcion_Z" )]
      [  XmlElement( ElementName = "EspectaculoDescripcion_Z"   )]
      public string gxTpr_Espectaculodescripcion_Z
      {
         get {
            return gxTv_SdtEspectaculo_Espectaculodescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEspectaculo_Espectaculodescripcion_Z = value;
            SetDirty("Espectaculodescripcion_Z");
         }

      }

      public void gxTv_SdtEspectaculo_Espectaculodescripcion_Z_SetNull( )
      {
         gxTv_SdtEspectaculo_Espectaculodescripcion_Z = "";
         SetDirty("Espectaculodescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_Espectaculodescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoEspectaculoId_Z" )]
      [  XmlElement( ElementName = "TipoEspectaculoId_Z"   )]
      public short gxTpr_Tipoespectaculoid_Z
      {
         get {
            return gxTv_SdtEspectaculo_Tipoespectaculoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEspectaculo_Tipoespectaculoid_Z = value;
            SetDirty("Tipoespectaculoid_Z");
         }

      }

      public void gxTv_SdtEspectaculo_Tipoespectaculoid_Z_SetNull( )
      {
         gxTv_SdtEspectaculo_Tipoespectaculoid_Z = 0;
         SetDirty("Tipoespectaculoid_Z");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_Tipoespectaculoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspectaculoImagen_GXI_Z" )]
      [  XmlElement( ElementName = "EspectaculoImagen_GXI_Z"   )]
      public string gxTpr_Espectaculoimagen_gxi_Z
      {
         get {
            return gxTv_SdtEspectaculo_Espectaculoimagen_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEspectaculo_Espectaculoimagen_gxi_Z = value;
            SetDirty("Espectaculoimagen_gxi_Z");
         }

      }

      public void gxTv_SdtEspectaculo_Espectaculoimagen_gxi_Z_SetNull( )
      {
         gxTv_SdtEspectaculo_Espectaculoimagen_gxi_Z = "";
         SetDirty("Espectaculoimagen_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_Espectaculoimagen_gxi_Z_IsNull( )
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
         gxTv_SdtEspectaculo_Espectaculonombre = "";
         gxTv_SdtEspectaculo_Espectaculodescripcion = "";
         gxTv_SdtEspectaculo_Espectaculoimagen = "";
         gxTv_SdtEspectaculo_Espectaculoimagen_gxi = "";
         gxTv_SdtEspectaculo_Mode = "";
         gxTv_SdtEspectaculo_Espectaculonombre_Z = "";
         gxTv_SdtEspectaculo_Espectaculodescripcion_Z = "";
         gxTv_SdtEspectaculo_Espectaculoimagen_gxi_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "espectaculo", "GeneXus.Programs.espectaculo_bc", new Object[] {context}, constructorCallingAssembly);;
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

      private short gxTv_SdtEspectaculo_Espectaculoid ;
      private short sdtIsNull ;
      private short gxTv_SdtEspectaculo_Tipoespectaculoid ;
      private short gxTv_SdtEspectaculo_Initialized ;
      private short gxTv_SdtEspectaculo_Espectaculoid_Z ;
      private short gxTv_SdtEspectaculo_Tipoespectaculoid_Z ;
      private string gxTv_SdtEspectaculo_Mode ;
      private string gxTv_SdtEspectaculo_Espectaculonombre ;
      private string gxTv_SdtEspectaculo_Espectaculodescripcion ;
      private string gxTv_SdtEspectaculo_Espectaculoimagen_gxi ;
      private string gxTv_SdtEspectaculo_Espectaculonombre_Z ;
      private string gxTv_SdtEspectaculo_Espectaculodescripcion_Z ;
      private string gxTv_SdtEspectaculo_Espectaculoimagen_gxi_Z ;
      private string gxTv_SdtEspectaculo_Espectaculoimagen ;
   }

   [DataContract(Name = @"Espectaculo", Namespace = "TallerGeneXus")]
   [GxJsonSerialization("default")]
   public class SdtEspectaculo_RESTInterface : GxGenericCollectionItem<SdtEspectaculo>
   {
      public SdtEspectaculo_RESTInterface( ) : base()
      {
      }

      public SdtEspectaculo_RESTInterface( SdtEspectaculo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EspectaculoId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Espectaculoid
      {
         get {
            return sdt.gxTpr_Espectaculoid ;
         }

         set {
            sdt.gxTpr_Espectaculoid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "EspectaculoNombre" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Espectaculonombre
      {
         get {
            return sdt.gxTpr_Espectaculonombre ;
         }

         set {
            sdt.gxTpr_Espectaculonombre = value;
         }

      }

      [DataMember( Name = "EspectaculoDescripcion" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Espectaculodescripcion
      {
         get {
            return sdt.gxTpr_Espectaculodescripcion ;
         }

         set {
            sdt.gxTpr_Espectaculodescripcion = value;
         }

      }

      [DataMember( Name = "EspectaculoImagen" , Order = 3 )]
      [GxUpload()]
      public string gxTpr_Espectaculoimagen
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Espectaculoimagen)) ? PathUtil.RelativeURL( sdt.gxTpr_Espectaculoimagen) : StringUtil.RTrim( sdt.gxTpr_Espectaculoimagen_gxi)) ;
         }

         set {
            sdt.gxTpr_Espectaculoimagen = value;
         }

      }

      [DataMember( Name = "TipoEspectaculoId" , Order = 4 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Tipoespectaculoid
      {
         get {
            return sdt.gxTpr_Tipoespectaculoid ;
         }

         set {
            sdt.gxTpr_Tipoespectaculoid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtEspectaculo sdt
      {
         get {
            return (SdtEspectaculo)Sdt ;
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
            sdt = new SdtEspectaculo() ;
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

   [DataContract(Name = @"Espectaculo", Namespace = "TallerGeneXus")]
   [GxJsonSerialization("default")]
   public class SdtEspectaculo_RESTLInterface : GxGenericCollectionItem<SdtEspectaculo>
   {
      public SdtEspectaculo_RESTLInterface( ) : base()
      {
      }

      public SdtEspectaculo_RESTLInterface( SdtEspectaculo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EspectaculoNombre" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Espectaculonombre
      {
         get {
            return sdt.gxTpr_Espectaculonombre ;
         }

         set {
            sdt.gxTpr_Espectaculonombre = value;
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

      public SdtEspectaculo sdt
      {
         get {
            return (SdtEspectaculo)Sdt ;
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
            sdt = new SdtEspectaculo() ;
         }
      }

   }

}
