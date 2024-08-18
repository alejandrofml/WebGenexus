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
   [XmlRoot(ElementName = "Invitacion" )]
   [XmlType(TypeName =  "Invitacion" , Namespace = "TallerGeneXus" )]
   [Serializable]
   public class SdtInvitacion : GxSilentTrnSdt
   {
      public SdtInvitacion( )
      {
      }

      public SdtInvitacion( IGxContext context )
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

      public void Load( short AV6InvitacionId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV6InvitacionId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"InvitacionId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Invitacion");
         metadata.Set("BT", "Invitacion");
         metadata.Set("PK", "[ \"InvitacionId\" ]");
         metadata.Set("PKAssigned", "[ \"InvitacionId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"EventoId\",\"SectorId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Invitacionid_Z");
         state.Add("gxTpr_Invitacionnombre_Z");
         state.Add("gxTpr_Invitacionnominada_Z");
         state.Add("gxTpr_Eventoid_Z");
         state.Add("gxTpr_Sectorid_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtInvitacion sdt;
         sdt = (SdtInvitacion)(source);
         gxTv_SdtInvitacion_Invitacionid = sdt.gxTv_SdtInvitacion_Invitacionid ;
         gxTv_SdtInvitacion_Invitacionnombre = sdt.gxTv_SdtInvitacion_Invitacionnombre ;
         gxTv_SdtInvitacion_Invitacionnominada = sdt.gxTv_SdtInvitacion_Invitacionnominada ;
         gxTv_SdtInvitacion_Eventoid = sdt.gxTv_SdtInvitacion_Eventoid ;
         gxTv_SdtInvitacion_Sectorid = sdt.gxTv_SdtInvitacion_Sectorid ;
         gxTv_SdtInvitacion_Mode = sdt.gxTv_SdtInvitacion_Mode ;
         gxTv_SdtInvitacion_Initialized = sdt.gxTv_SdtInvitacion_Initialized ;
         gxTv_SdtInvitacion_Invitacionid_Z = sdt.gxTv_SdtInvitacion_Invitacionid_Z ;
         gxTv_SdtInvitacion_Invitacionnombre_Z = sdt.gxTv_SdtInvitacion_Invitacionnombre_Z ;
         gxTv_SdtInvitacion_Invitacionnominada_Z = sdt.gxTv_SdtInvitacion_Invitacionnominada_Z ;
         gxTv_SdtInvitacion_Eventoid_Z = sdt.gxTv_SdtInvitacion_Eventoid_Z ;
         gxTv_SdtInvitacion_Sectorid_Z = sdt.gxTv_SdtInvitacion_Sectorid_Z ;
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
         AddObjectProperty("InvitacionId", gxTv_SdtInvitacion_Invitacionid, false, includeNonInitialized);
         AddObjectProperty("InvitacionNombre", gxTv_SdtInvitacion_Invitacionnombre, false, includeNonInitialized);
         AddObjectProperty("InvitacionNominada", gxTv_SdtInvitacion_Invitacionnominada, false, includeNonInitialized);
         AddObjectProperty("EventoId", gxTv_SdtInvitacion_Eventoid, false, includeNonInitialized);
         AddObjectProperty("SectorId", gxTv_SdtInvitacion_Sectorid, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtInvitacion_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtInvitacion_Initialized, false, includeNonInitialized);
            AddObjectProperty("InvitacionId_Z", gxTv_SdtInvitacion_Invitacionid_Z, false, includeNonInitialized);
            AddObjectProperty("InvitacionNombre_Z", gxTv_SdtInvitacion_Invitacionnombre_Z, false, includeNonInitialized);
            AddObjectProperty("InvitacionNominada_Z", gxTv_SdtInvitacion_Invitacionnominada_Z, false, includeNonInitialized);
            AddObjectProperty("EventoId_Z", gxTv_SdtInvitacion_Eventoid_Z, false, includeNonInitialized);
            AddObjectProperty("SectorId_Z", gxTv_SdtInvitacion_Sectorid_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtInvitacion sdt )
      {
         if ( sdt.IsDirty("InvitacionId") )
         {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Invitacionid = sdt.gxTv_SdtInvitacion_Invitacionid ;
         }
         if ( sdt.IsDirty("InvitacionNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Invitacionnombre = sdt.gxTv_SdtInvitacion_Invitacionnombre ;
         }
         if ( sdt.IsDirty("InvitacionNominada") )
         {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Invitacionnominada = sdt.gxTv_SdtInvitacion_Invitacionnominada ;
         }
         if ( sdt.IsDirty("EventoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Eventoid = sdt.gxTv_SdtInvitacion_Eventoid ;
         }
         if ( sdt.IsDirty("SectorId") )
         {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Sectorid = sdt.gxTv_SdtInvitacion_Sectorid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "InvitacionId" )]
      [  XmlElement( ElementName = "InvitacionId"   )]
      public short gxTpr_Invitacionid
      {
         get {
            return gxTv_SdtInvitacion_Invitacionid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtInvitacion_Invitacionid != value )
            {
               gxTv_SdtInvitacion_Mode = "INS";
               this.gxTv_SdtInvitacion_Invitacionid_Z_SetNull( );
               this.gxTv_SdtInvitacion_Invitacionnombre_Z_SetNull( );
               this.gxTv_SdtInvitacion_Invitacionnominada_Z_SetNull( );
               this.gxTv_SdtInvitacion_Eventoid_Z_SetNull( );
               this.gxTv_SdtInvitacion_Sectorid_Z_SetNull( );
            }
            gxTv_SdtInvitacion_Invitacionid = value;
            SetDirty("Invitacionid");
         }

      }

      [  SoapElement( ElementName = "InvitacionNombre" )]
      [  XmlElement( ElementName = "InvitacionNombre"   )]
      public string gxTpr_Invitacionnombre
      {
         get {
            return gxTv_SdtInvitacion_Invitacionnombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Invitacionnombre = value;
            SetDirty("Invitacionnombre");
         }

      }

      [  SoapElement( ElementName = "InvitacionNominada" )]
      [  XmlElement( ElementName = "InvitacionNominada"   )]
      public bool gxTpr_Invitacionnominada
      {
         get {
            return gxTv_SdtInvitacion_Invitacionnominada ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Invitacionnominada = value;
            SetDirty("Invitacionnominada");
         }

      }

      [  SoapElement( ElementName = "EventoId" )]
      [  XmlElement( ElementName = "EventoId"   )]
      public short gxTpr_Eventoid
      {
         get {
            return gxTv_SdtInvitacion_Eventoid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Eventoid = value;
            SetDirty("Eventoid");
         }

      }

      [  SoapElement( ElementName = "SectorId" )]
      [  XmlElement( ElementName = "SectorId"   )]
      public short gxTpr_Sectorid
      {
         get {
            return gxTv_SdtInvitacion_Sectorid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Sectorid = value;
            SetDirty("Sectorid");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtInvitacion_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtInvitacion_Mode_SetNull( )
      {
         gxTv_SdtInvitacion_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtInvitacion_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtInvitacion_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtInvitacion_Initialized_SetNull( )
      {
         gxTv_SdtInvitacion_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtInvitacion_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvitacionId_Z" )]
      [  XmlElement( ElementName = "InvitacionId_Z"   )]
      public short gxTpr_Invitacionid_Z
      {
         get {
            return gxTv_SdtInvitacion_Invitacionid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Invitacionid_Z = value;
            SetDirty("Invitacionid_Z");
         }

      }

      public void gxTv_SdtInvitacion_Invitacionid_Z_SetNull( )
      {
         gxTv_SdtInvitacion_Invitacionid_Z = 0;
         SetDirty("Invitacionid_Z");
         return  ;
      }

      public bool gxTv_SdtInvitacion_Invitacionid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvitacionNombre_Z" )]
      [  XmlElement( ElementName = "InvitacionNombre_Z"   )]
      public string gxTpr_Invitacionnombre_Z
      {
         get {
            return gxTv_SdtInvitacion_Invitacionnombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Invitacionnombre_Z = value;
            SetDirty("Invitacionnombre_Z");
         }

      }

      public void gxTv_SdtInvitacion_Invitacionnombre_Z_SetNull( )
      {
         gxTv_SdtInvitacion_Invitacionnombre_Z = "";
         SetDirty("Invitacionnombre_Z");
         return  ;
      }

      public bool gxTv_SdtInvitacion_Invitacionnombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvitacionNominada_Z" )]
      [  XmlElement( ElementName = "InvitacionNominada_Z"   )]
      public bool gxTpr_Invitacionnominada_Z
      {
         get {
            return gxTv_SdtInvitacion_Invitacionnominada_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Invitacionnominada_Z = value;
            SetDirty("Invitacionnominada_Z");
         }

      }

      public void gxTv_SdtInvitacion_Invitacionnominada_Z_SetNull( )
      {
         gxTv_SdtInvitacion_Invitacionnominada_Z = false;
         SetDirty("Invitacionnominada_Z");
         return  ;
      }

      public bool gxTv_SdtInvitacion_Invitacionnominada_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EventoId_Z" )]
      [  XmlElement( ElementName = "EventoId_Z"   )]
      public short gxTpr_Eventoid_Z
      {
         get {
            return gxTv_SdtInvitacion_Eventoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Eventoid_Z = value;
            SetDirty("Eventoid_Z");
         }

      }

      public void gxTv_SdtInvitacion_Eventoid_Z_SetNull( )
      {
         gxTv_SdtInvitacion_Eventoid_Z = 0;
         SetDirty("Eventoid_Z");
         return  ;
      }

      public bool gxTv_SdtInvitacion_Eventoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SectorId_Z" )]
      [  XmlElement( ElementName = "SectorId_Z"   )]
      public short gxTpr_Sectorid_Z
      {
         get {
            return gxTv_SdtInvitacion_Sectorid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtInvitacion_Sectorid_Z = value;
            SetDirty("Sectorid_Z");
         }

      }

      public void gxTv_SdtInvitacion_Sectorid_Z_SetNull( )
      {
         gxTv_SdtInvitacion_Sectorid_Z = 0;
         SetDirty("Sectorid_Z");
         return  ;
      }

      public bool gxTv_SdtInvitacion_Sectorid_Z_IsNull( )
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
         gxTv_SdtInvitacion_Invitacionnombre = "";
         gxTv_SdtInvitacion_Mode = "";
         gxTv_SdtInvitacion_Invitacionnombre_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "invitacion", "GeneXus.Programs.invitacion_bc", new Object[] {context}, constructorCallingAssembly);;
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

      private short gxTv_SdtInvitacion_Invitacionid ;
      private short sdtIsNull ;
      private short gxTv_SdtInvitacion_Eventoid ;
      private short gxTv_SdtInvitacion_Sectorid ;
      private short gxTv_SdtInvitacion_Initialized ;
      private short gxTv_SdtInvitacion_Invitacionid_Z ;
      private short gxTv_SdtInvitacion_Eventoid_Z ;
      private short gxTv_SdtInvitacion_Sectorid_Z ;
      private string gxTv_SdtInvitacion_Mode ;
      private bool gxTv_SdtInvitacion_Invitacionnominada ;
      private bool gxTv_SdtInvitacion_Invitacionnominada_Z ;
      private string gxTv_SdtInvitacion_Invitacionnombre ;
      private string gxTv_SdtInvitacion_Invitacionnombre_Z ;
   }

   [DataContract(Name = @"Invitacion", Namespace = "TallerGeneXus")]
   [GxJsonSerialization("default")]
   public class SdtInvitacion_RESTInterface : GxGenericCollectionItem<SdtInvitacion>
   {
      public SdtInvitacion_RESTInterface( ) : base()
      {
      }

      public SdtInvitacion_RESTInterface( SdtInvitacion psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "InvitacionId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Invitacionid
      {
         get {
            return sdt.gxTpr_Invitacionid ;
         }

         set {
            sdt.gxTpr_Invitacionid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "InvitacionNombre" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Invitacionnombre
      {
         get {
            return sdt.gxTpr_Invitacionnombre ;
         }

         set {
            sdt.gxTpr_Invitacionnombre = value;
         }

      }

      [DataMember( Name = "InvitacionNominada" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Invitacionnominada
      {
         get {
            return sdt.gxTpr_Invitacionnominada ;
         }

         set {
            sdt.gxTpr_Invitacionnominada = value;
         }

      }

      [DataMember( Name = "EventoId" , Order = 3 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Eventoid
      {
         get {
            return sdt.gxTpr_Eventoid ;
         }

         set {
            sdt.gxTpr_Eventoid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "SectorId" , Order = 4 )]
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

      public SdtInvitacion sdt
      {
         get {
            return (SdtInvitacion)Sdt ;
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
            sdt = new SdtInvitacion() ;
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

   [DataContract(Name = @"Invitacion", Namespace = "TallerGeneXus")]
   [GxJsonSerialization("default")]
   public class SdtInvitacion_RESTLInterface : GxGenericCollectionItem<SdtInvitacion>
   {
      public SdtInvitacion_RESTLInterface( ) : base()
      {
      }

      public SdtInvitacion_RESTLInterface( SdtInvitacion psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "InvitacionNominada" , Order = 0 )]
      [GxSeudo()]
      public bool gxTpr_Invitacionnominada
      {
         get {
            return sdt.gxTpr_Invitacionnominada ;
         }

         set {
            sdt.gxTpr_Invitacionnominada = value;
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

      public SdtInvitacion sdt
      {
         get {
            return (SdtInvitacion)Sdt ;
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
            sdt = new SdtInvitacion() ;
         }
      }

   }

}
