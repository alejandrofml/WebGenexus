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
   [XmlRoot(ElementName = "Evento.Invitaciones" )]
   [XmlType(TypeName =  "Evento.Invitaciones" , Namespace = "TallerGeneXus" )]
   [Serializable]
   public class SdtEvento_Invitaciones : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtEvento_Invitaciones( )
      {
      }

      public SdtEvento_Invitaciones( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"InvitacionId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Invitaciones");
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
         state.Add("gxTpr_Modified");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Invitacionid_Z");
         state.Add("gxTpr_Invitacionnombre_Z");
         state.Add("gxTpr_Invitacionnominada_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtEvento_Invitaciones sdt;
         sdt = (SdtEvento_Invitaciones)(source);
         gxTv_SdtEvento_Invitaciones_Invitacionid = sdt.gxTv_SdtEvento_Invitaciones_Invitacionid ;
         gxTv_SdtEvento_Invitaciones_Invitacionnombre = sdt.gxTv_SdtEvento_Invitaciones_Invitacionnombre ;
         gxTv_SdtEvento_Invitaciones_Invitacionnominada = sdt.gxTv_SdtEvento_Invitaciones_Invitacionnominada ;
         gxTv_SdtEvento_Invitaciones_Mode = sdt.gxTv_SdtEvento_Invitaciones_Mode ;
         gxTv_SdtEvento_Invitaciones_Modified = sdt.gxTv_SdtEvento_Invitaciones_Modified ;
         gxTv_SdtEvento_Invitaciones_Initialized = sdt.gxTv_SdtEvento_Invitaciones_Initialized ;
         gxTv_SdtEvento_Invitaciones_Invitacionid_Z = sdt.gxTv_SdtEvento_Invitaciones_Invitacionid_Z ;
         gxTv_SdtEvento_Invitaciones_Invitacionnombre_Z = sdt.gxTv_SdtEvento_Invitaciones_Invitacionnombre_Z ;
         gxTv_SdtEvento_Invitaciones_Invitacionnominada_Z = sdt.gxTv_SdtEvento_Invitaciones_Invitacionnominada_Z ;
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
         AddObjectProperty("InvitacionId", gxTv_SdtEvento_Invitaciones_Invitacionid, false, includeNonInitialized);
         AddObjectProperty("InvitacionNombre", gxTv_SdtEvento_Invitaciones_Invitacionnombre, false, includeNonInitialized);
         AddObjectProperty("InvitacionNominada", gxTv_SdtEvento_Invitaciones_Invitacionnominada, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtEvento_Invitaciones_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtEvento_Invitaciones_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtEvento_Invitaciones_Initialized, false, includeNonInitialized);
            AddObjectProperty("InvitacionId_Z", gxTv_SdtEvento_Invitaciones_Invitacionid_Z, false, includeNonInitialized);
            AddObjectProperty("InvitacionNombre_Z", gxTv_SdtEvento_Invitaciones_Invitacionnombre_Z, false, includeNonInitialized);
            AddObjectProperty("InvitacionNominada_Z", gxTv_SdtEvento_Invitaciones_Invitacionnominada_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtEvento_Invitaciones sdt )
      {
         if ( sdt.IsDirty("InvitacionId") )
         {
            sdtIsNull = 0;
            gxTv_SdtEvento_Invitaciones_Invitacionid = sdt.gxTv_SdtEvento_Invitaciones_Invitacionid ;
         }
         if ( sdt.IsDirty("InvitacionNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtEvento_Invitaciones_Invitacionnombre = sdt.gxTv_SdtEvento_Invitaciones_Invitacionnombre ;
         }
         if ( sdt.IsDirty("InvitacionNominada") )
         {
            sdtIsNull = 0;
            gxTv_SdtEvento_Invitaciones_Invitacionnominada = sdt.gxTv_SdtEvento_Invitaciones_Invitacionnominada ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "InvitacionId" )]
      [  XmlElement( ElementName = "InvitacionId"   )]
      public short gxTpr_Invitacionid
      {
         get {
            return gxTv_SdtEvento_Invitaciones_Invitacionid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEvento_Invitaciones_Invitacionid = value;
            gxTv_SdtEvento_Invitaciones_Modified = 1;
            SetDirty("Invitacionid");
         }

      }

      [  SoapElement( ElementName = "InvitacionNombre" )]
      [  XmlElement( ElementName = "InvitacionNombre"   )]
      public string gxTpr_Invitacionnombre
      {
         get {
            return gxTv_SdtEvento_Invitaciones_Invitacionnombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEvento_Invitaciones_Invitacionnombre = value;
            gxTv_SdtEvento_Invitaciones_Modified = 1;
            SetDirty("Invitacionnombre");
         }

      }

      [  SoapElement( ElementName = "InvitacionNominada" )]
      [  XmlElement( ElementName = "InvitacionNominada"   )]
      public bool gxTpr_Invitacionnominada
      {
         get {
            return gxTv_SdtEvento_Invitaciones_Invitacionnominada ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEvento_Invitaciones_Invitacionnominada = value;
            gxTv_SdtEvento_Invitaciones_Modified = 1;
            SetDirty("Invitacionnominada");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtEvento_Invitaciones_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEvento_Invitaciones_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtEvento_Invitaciones_Mode_SetNull( )
      {
         gxTv_SdtEvento_Invitaciones_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtEvento_Invitaciones_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtEvento_Invitaciones_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEvento_Invitaciones_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtEvento_Invitaciones_Modified_SetNull( )
      {
         gxTv_SdtEvento_Invitaciones_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtEvento_Invitaciones_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtEvento_Invitaciones_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEvento_Invitaciones_Initialized = value;
            gxTv_SdtEvento_Invitaciones_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtEvento_Invitaciones_Initialized_SetNull( )
      {
         gxTv_SdtEvento_Invitaciones_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtEvento_Invitaciones_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvitacionId_Z" )]
      [  XmlElement( ElementName = "InvitacionId_Z"   )]
      public short gxTpr_Invitacionid_Z
      {
         get {
            return gxTv_SdtEvento_Invitaciones_Invitacionid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEvento_Invitaciones_Invitacionid_Z = value;
            gxTv_SdtEvento_Invitaciones_Modified = 1;
            SetDirty("Invitacionid_Z");
         }

      }

      public void gxTv_SdtEvento_Invitaciones_Invitacionid_Z_SetNull( )
      {
         gxTv_SdtEvento_Invitaciones_Invitacionid_Z = 0;
         SetDirty("Invitacionid_Z");
         return  ;
      }

      public bool gxTv_SdtEvento_Invitaciones_Invitacionid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvitacionNombre_Z" )]
      [  XmlElement( ElementName = "InvitacionNombre_Z"   )]
      public string gxTpr_Invitacionnombre_Z
      {
         get {
            return gxTv_SdtEvento_Invitaciones_Invitacionnombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEvento_Invitaciones_Invitacionnombre_Z = value;
            gxTv_SdtEvento_Invitaciones_Modified = 1;
            SetDirty("Invitacionnombre_Z");
         }

      }

      public void gxTv_SdtEvento_Invitaciones_Invitacionnombre_Z_SetNull( )
      {
         gxTv_SdtEvento_Invitaciones_Invitacionnombre_Z = "";
         SetDirty("Invitacionnombre_Z");
         return  ;
      }

      public bool gxTv_SdtEvento_Invitaciones_Invitacionnombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvitacionNominada_Z" )]
      [  XmlElement( ElementName = "InvitacionNominada_Z"   )]
      public bool gxTpr_Invitacionnominada_Z
      {
         get {
            return gxTv_SdtEvento_Invitaciones_Invitacionnominada_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEvento_Invitaciones_Invitacionnominada_Z = value;
            gxTv_SdtEvento_Invitaciones_Modified = 1;
            SetDirty("Invitacionnominada_Z");
         }

      }

      public void gxTv_SdtEvento_Invitaciones_Invitacionnominada_Z_SetNull( )
      {
         gxTv_SdtEvento_Invitaciones_Invitacionnominada_Z = false;
         SetDirty("Invitacionnominada_Z");
         return  ;
      }

      public bool gxTv_SdtEvento_Invitaciones_Invitacionnominada_Z_IsNull( )
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
         gxTv_SdtEvento_Invitaciones_Invitacionnombre = "";
         gxTv_SdtEvento_Invitaciones_Mode = "";
         gxTv_SdtEvento_Invitaciones_Invitacionnombre_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short gxTv_SdtEvento_Invitaciones_Invitacionid ;
      private short sdtIsNull ;
      private short gxTv_SdtEvento_Invitaciones_Modified ;
      private short gxTv_SdtEvento_Invitaciones_Initialized ;
      private short gxTv_SdtEvento_Invitaciones_Invitacionid_Z ;
      private string gxTv_SdtEvento_Invitaciones_Mode ;
      private bool gxTv_SdtEvento_Invitaciones_Invitacionnominada ;
      private bool gxTv_SdtEvento_Invitaciones_Invitacionnominada_Z ;
      private string gxTv_SdtEvento_Invitaciones_Invitacionnombre ;
      private string gxTv_SdtEvento_Invitaciones_Invitacionnombre_Z ;
   }

   [DataContract(Name = @"Evento.Invitaciones", Namespace = "TallerGeneXus")]
   [GxJsonSerialization("default")]
   public class SdtEvento_Invitaciones_RESTInterface : GxGenericCollectionItem<SdtEvento_Invitaciones>
   {
      public SdtEvento_Invitaciones_RESTInterface( ) : base()
      {
      }

      public SdtEvento_Invitaciones_RESTInterface( SdtEvento_Invitaciones psdt ) : base(psdt)
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

      public SdtEvento_Invitaciones sdt
      {
         get {
            return (SdtEvento_Invitaciones)Sdt ;
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
            sdt = new SdtEvento_Invitaciones() ;
         }
      }

   }

   [DataContract(Name = @"Evento.Invitaciones", Namespace = "TallerGeneXus")]
   [GxJsonSerialization("default")]
   public class SdtEvento_Invitaciones_RESTLInterface : GxGenericCollectionItem<SdtEvento_Invitaciones>
   {
      public SdtEvento_Invitaciones_RESTLInterface( ) : base()
      {
      }

      public SdtEvento_Invitaciones_RESTLInterface( SdtEvento_Invitaciones psdt ) : base(psdt)
      {
      }

      public SdtEvento_Invitaciones sdt
      {
         get {
            return (SdtEvento_Invitaciones)Sdt ;
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
            sdt = new SdtEvento_Invitaciones() ;
         }
      }

   }

}
