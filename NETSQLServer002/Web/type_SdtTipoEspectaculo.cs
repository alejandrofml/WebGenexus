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
   [XmlRoot(ElementName = "TipoEspectaculo" )]
   [XmlType(TypeName =  "TipoEspectaculo" , Namespace = "TallerGeneXus" )]
   [Serializable]
   public class SdtTipoEspectaculo : GxSilentTrnSdt
   {
      public SdtTipoEspectaculo( )
      {
      }

      public SdtTipoEspectaculo( IGxContext context )
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

      public void Load( short AV2TipoEspectaculoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV2TipoEspectaculoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"TipoEspectaculoId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "TipoEspectaculo");
         metadata.Set("BT", "TipoEspectaculo");
         metadata.Set("PK", "[ \"TipoEspectaculoId\" ]");
         metadata.Set("PKAssigned", "[ \"TipoEspectaculoId\" ]");
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
         state.Add("gxTpr_Tipoespectaculoid_Z");
         state.Add("gxTpr_Tipoespectaculonombre_Z");
         state.Add("gxTpr_Cantidadespectaculos_Z");
         state.Add("gxTpr_Cantidadespectaculos_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTipoEspectaculo sdt;
         sdt = (SdtTipoEspectaculo)(source);
         gxTv_SdtTipoEspectaculo_Tipoespectaculoid = sdt.gxTv_SdtTipoEspectaculo_Tipoespectaculoid ;
         gxTv_SdtTipoEspectaculo_Tipoespectaculonombre = sdt.gxTv_SdtTipoEspectaculo_Tipoespectaculonombre ;
         gxTv_SdtTipoEspectaculo_Cantidadespectaculos = sdt.gxTv_SdtTipoEspectaculo_Cantidadespectaculos ;
         gxTv_SdtTipoEspectaculo_Mode = sdt.gxTv_SdtTipoEspectaculo_Mode ;
         gxTv_SdtTipoEspectaculo_Initialized = sdt.gxTv_SdtTipoEspectaculo_Initialized ;
         gxTv_SdtTipoEspectaculo_Tipoespectaculoid_Z = sdt.gxTv_SdtTipoEspectaculo_Tipoespectaculoid_Z ;
         gxTv_SdtTipoEspectaculo_Tipoespectaculonombre_Z = sdt.gxTv_SdtTipoEspectaculo_Tipoespectaculonombre_Z ;
         gxTv_SdtTipoEspectaculo_Cantidadespectaculos_Z = sdt.gxTv_SdtTipoEspectaculo_Cantidadespectaculos_Z ;
         gxTv_SdtTipoEspectaculo_Cantidadespectaculos_N = sdt.gxTv_SdtTipoEspectaculo_Cantidadespectaculos_N ;
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
         AddObjectProperty("TipoEspectaculoId", gxTv_SdtTipoEspectaculo_Tipoespectaculoid, false, includeNonInitialized);
         AddObjectProperty("TipoEspectaculoNombre", gxTv_SdtTipoEspectaculo_Tipoespectaculonombre, false, includeNonInitialized);
         AddObjectProperty("CantidadEspectaculos", gxTv_SdtTipoEspectaculo_Cantidadespectaculos, false, includeNonInitialized);
         AddObjectProperty("CantidadEspectaculos_N", gxTv_SdtTipoEspectaculo_Cantidadespectaculos_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTipoEspectaculo_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTipoEspectaculo_Initialized, false, includeNonInitialized);
            AddObjectProperty("TipoEspectaculoId_Z", gxTv_SdtTipoEspectaculo_Tipoespectaculoid_Z, false, includeNonInitialized);
            AddObjectProperty("TipoEspectaculoNombre_Z", gxTv_SdtTipoEspectaculo_Tipoespectaculonombre_Z, false, includeNonInitialized);
            AddObjectProperty("CantidadEspectaculos_Z", gxTv_SdtTipoEspectaculo_Cantidadespectaculos_Z, false, includeNonInitialized);
            AddObjectProperty("CantidadEspectaculos_N", gxTv_SdtTipoEspectaculo_Cantidadespectaculos_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTipoEspectaculo sdt )
      {
         if ( sdt.IsDirty("TipoEspectaculoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTipoEspectaculo_Tipoespectaculoid = sdt.gxTv_SdtTipoEspectaculo_Tipoespectaculoid ;
         }
         if ( sdt.IsDirty("TipoEspectaculoNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtTipoEspectaculo_Tipoespectaculonombre = sdt.gxTv_SdtTipoEspectaculo_Tipoespectaculonombre ;
         }
         if ( sdt.IsDirty("CantidadEspectaculos") )
         {
            gxTv_SdtTipoEspectaculo_Cantidadespectaculos_N = (short)(sdt.gxTv_SdtTipoEspectaculo_Cantidadespectaculos_N);
            sdtIsNull = 0;
            gxTv_SdtTipoEspectaculo_Cantidadespectaculos = sdt.gxTv_SdtTipoEspectaculo_Cantidadespectaculos ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "TipoEspectaculoId" )]
      [  XmlElement( ElementName = "TipoEspectaculoId"   )]
      public short gxTpr_Tipoespectaculoid
      {
         get {
            return gxTv_SdtTipoEspectaculo_Tipoespectaculoid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTipoEspectaculo_Tipoespectaculoid != value )
            {
               gxTv_SdtTipoEspectaculo_Mode = "INS";
               this.gxTv_SdtTipoEspectaculo_Tipoespectaculoid_Z_SetNull( );
               this.gxTv_SdtTipoEspectaculo_Tipoespectaculonombre_Z_SetNull( );
               this.gxTv_SdtTipoEspectaculo_Cantidadespectaculos_Z_SetNull( );
            }
            gxTv_SdtTipoEspectaculo_Tipoespectaculoid = value;
            SetDirty("Tipoespectaculoid");
         }

      }

      [  SoapElement( ElementName = "TipoEspectaculoNombre" )]
      [  XmlElement( ElementName = "TipoEspectaculoNombre"   )]
      public string gxTpr_Tipoespectaculonombre
      {
         get {
            return gxTv_SdtTipoEspectaculo_Tipoespectaculonombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTipoEspectaculo_Tipoespectaculonombre = value;
            SetDirty("Tipoespectaculonombre");
         }

      }

      [  SoapElement( ElementName = "CantidadEspectaculos" )]
      [  XmlElement( ElementName = "CantidadEspectaculos"   )]
      public short gxTpr_Cantidadespectaculos
      {
         get {
            return gxTv_SdtTipoEspectaculo_Cantidadespectaculos ;
         }

         set {
            gxTv_SdtTipoEspectaculo_Cantidadespectaculos_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTipoEspectaculo_Cantidadespectaculos = value;
            SetDirty("Cantidadespectaculos");
         }

      }

      public void gxTv_SdtTipoEspectaculo_Cantidadespectaculos_SetNull( )
      {
         gxTv_SdtTipoEspectaculo_Cantidadespectaculos_N = 1;
         gxTv_SdtTipoEspectaculo_Cantidadespectaculos = 0;
         SetDirty("Cantidadespectaculos");
         return  ;
      }

      public bool gxTv_SdtTipoEspectaculo_Cantidadespectaculos_IsNull( )
      {
         return (gxTv_SdtTipoEspectaculo_Cantidadespectaculos_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTipoEspectaculo_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTipoEspectaculo_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTipoEspectaculo_Mode_SetNull( )
      {
         gxTv_SdtTipoEspectaculo_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTipoEspectaculo_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTipoEspectaculo_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTipoEspectaculo_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTipoEspectaculo_Initialized_SetNull( )
      {
         gxTv_SdtTipoEspectaculo_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTipoEspectaculo_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoEspectaculoId_Z" )]
      [  XmlElement( ElementName = "TipoEspectaculoId_Z"   )]
      public short gxTpr_Tipoespectaculoid_Z
      {
         get {
            return gxTv_SdtTipoEspectaculo_Tipoespectaculoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTipoEspectaculo_Tipoespectaculoid_Z = value;
            SetDirty("Tipoespectaculoid_Z");
         }

      }

      public void gxTv_SdtTipoEspectaculo_Tipoespectaculoid_Z_SetNull( )
      {
         gxTv_SdtTipoEspectaculo_Tipoespectaculoid_Z = 0;
         SetDirty("Tipoespectaculoid_Z");
         return  ;
      }

      public bool gxTv_SdtTipoEspectaculo_Tipoespectaculoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoEspectaculoNombre_Z" )]
      [  XmlElement( ElementName = "TipoEspectaculoNombre_Z"   )]
      public string gxTpr_Tipoespectaculonombre_Z
      {
         get {
            return gxTv_SdtTipoEspectaculo_Tipoespectaculonombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTipoEspectaculo_Tipoespectaculonombre_Z = value;
            SetDirty("Tipoespectaculonombre_Z");
         }

      }

      public void gxTv_SdtTipoEspectaculo_Tipoespectaculonombre_Z_SetNull( )
      {
         gxTv_SdtTipoEspectaculo_Tipoespectaculonombre_Z = "";
         SetDirty("Tipoespectaculonombre_Z");
         return  ;
      }

      public bool gxTv_SdtTipoEspectaculo_Tipoespectaculonombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CantidadEspectaculos_Z" )]
      [  XmlElement( ElementName = "CantidadEspectaculos_Z"   )]
      public short gxTpr_Cantidadespectaculos_Z
      {
         get {
            return gxTv_SdtTipoEspectaculo_Cantidadespectaculos_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTipoEspectaculo_Cantidadespectaculos_Z = value;
            SetDirty("Cantidadespectaculos_Z");
         }

      }

      public void gxTv_SdtTipoEspectaculo_Cantidadespectaculos_Z_SetNull( )
      {
         gxTv_SdtTipoEspectaculo_Cantidadespectaculos_Z = 0;
         SetDirty("Cantidadespectaculos_Z");
         return  ;
      }

      public bool gxTv_SdtTipoEspectaculo_Cantidadespectaculos_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CantidadEspectaculos_N" )]
      [  XmlElement( ElementName = "CantidadEspectaculos_N"   )]
      public short gxTpr_Cantidadespectaculos_N
      {
         get {
            return gxTv_SdtTipoEspectaculo_Cantidadespectaculos_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTipoEspectaculo_Cantidadespectaculos_N = value;
            SetDirty("Cantidadespectaculos_N");
         }

      }

      public void gxTv_SdtTipoEspectaculo_Cantidadespectaculos_N_SetNull( )
      {
         gxTv_SdtTipoEspectaculo_Cantidadespectaculos_N = 0;
         SetDirty("Cantidadespectaculos_N");
         return  ;
      }

      public bool gxTv_SdtTipoEspectaculo_Cantidadespectaculos_N_IsNull( )
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
         gxTv_SdtTipoEspectaculo_Tipoespectaculonombre = "";
         gxTv_SdtTipoEspectaculo_Mode = "";
         gxTv_SdtTipoEspectaculo_Tipoespectaculonombre_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "tipoespectaculo", "GeneXus.Programs.tipoespectaculo_bc", new Object[] {context}, constructorCallingAssembly);;
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

      private short gxTv_SdtTipoEspectaculo_Tipoespectaculoid ;
      private short sdtIsNull ;
      private short gxTv_SdtTipoEspectaculo_Cantidadespectaculos ;
      private short gxTv_SdtTipoEspectaculo_Initialized ;
      private short gxTv_SdtTipoEspectaculo_Tipoespectaculoid_Z ;
      private short gxTv_SdtTipoEspectaculo_Cantidadespectaculos_Z ;
      private short gxTv_SdtTipoEspectaculo_Cantidadespectaculos_N ;
      private string gxTv_SdtTipoEspectaculo_Mode ;
      private string gxTv_SdtTipoEspectaculo_Tipoespectaculonombre ;
      private string gxTv_SdtTipoEspectaculo_Tipoespectaculonombre_Z ;
   }

   [DataContract(Name = @"TipoEspectaculo", Namespace = "TallerGeneXus")]
   [GxJsonSerialization("default")]
   public class SdtTipoEspectaculo_RESTInterface : GxGenericCollectionItem<SdtTipoEspectaculo>
   {
      public SdtTipoEspectaculo_RESTInterface( ) : base()
      {
      }

      public SdtTipoEspectaculo_RESTInterface( SdtTipoEspectaculo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TipoEspectaculoId" , Order = 0 )]
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

      [DataMember( Name = "TipoEspectaculoNombre" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Tipoespectaculonombre
      {
         get {
            return sdt.gxTpr_Tipoespectaculonombre ;
         }

         set {
            sdt.gxTpr_Tipoespectaculonombre = value;
         }

      }

      [DataMember( Name = "CantidadEspectaculos" , Order = 2 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Cantidadespectaculos
      {
         get {
            return sdt.gxTpr_Cantidadespectaculos ;
         }

         set {
            sdt.gxTpr_Cantidadespectaculos = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtTipoEspectaculo sdt
      {
         get {
            return (SdtTipoEspectaculo)Sdt ;
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
            sdt = new SdtTipoEspectaculo() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 3 )]
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

   [DataContract(Name = @"TipoEspectaculo", Namespace = "TallerGeneXus")]
   [GxJsonSerialization("default")]
   public class SdtTipoEspectaculo_RESTLInterface : GxGenericCollectionItem<SdtTipoEspectaculo>
   {
      public SdtTipoEspectaculo_RESTLInterface( ) : base()
      {
      }

      public SdtTipoEspectaculo_RESTLInterface( SdtTipoEspectaculo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TipoEspectaculoNombre" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Tipoespectaculonombre
      {
         get {
            return sdt.gxTpr_Tipoespectaculonombre ;
         }

         set {
            sdt.gxTpr_Tipoespectaculonombre = value;
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

      public SdtTipoEspectaculo sdt
      {
         get {
            return (SdtTipoEspectaculo)Sdt ;
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
            sdt = new SdtTipoEspectaculo() ;
         }
      }

   }

}
