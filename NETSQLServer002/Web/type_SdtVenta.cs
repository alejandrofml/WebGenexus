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
   [XmlRoot(ElementName = "Venta" )]
   [XmlType(TypeName =  "Venta" , Namespace = "TallerGeneXus" )]
   [Serializable]
   public class SdtVenta : GxSilentTrnSdt
   {
      public SdtVenta( )
      {
      }

      public SdtVenta( IGxContext context )
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

      public void Load( short AV8VentaId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV8VentaId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"VentaId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Venta");
         metadata.Set("BT", "Venta");
         metadata.Set("PK", "[ \"VentaId\" ]");
         metadata.Set("PKAssigned", "[ \"VentaId\" ]");
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
         state.Add("gxTpr_Ventaid_Z");
         state.Add("gxTpr_Ventahorafecha_Z_Nullable");
         state.Add("gxTpr_Sectorid_Z");
         state.Add("gxTpr_Eventoid_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtVenta sdt;
         sdt = (SdtVenta)(source);
         gxTv_SdtVenta_Ventaid = sdt.gxTv_SdtVenta_Ventaid ;
         gxTv_SdtVenta_Ventahorafecha = sdt.gxTv_SdtVenta_Ventahorafecha ;
         gxTv_SdtVenta_Sectorid = sdt.gxTv_SdtVenta_Sectorid ;
         gxTv_SdtVenta_Eventoid = sdt.gxTv_SdtVenta_Eventoid ;
         gxTv_SdtVenta_Mode = sdt.gxTv_SdtVenta_Mode ;
         gxTv_SdtVenta_Initialized = sdt.gxTv_SdtVenta_Initialized ;
         gxTv_SdtVenta_Ventaid_Z = sdt.gxTv_SdtVenta_Ventaid_Z ;
         gxTv_SdtVenta_Ventahorafecha_Z = sdt.gxTv_SdtVenta_Ventahorafecha_Z ;
         gxTv_SdtVenta_Sectorid_Z = sdt.gxTv_SdtVenta_Sectorid_Z ;
         gxTv_SdtVenta_Eventoid_Z = sdt.gxTv_SdtVenta_Eventoid_Z ;
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
         AddObjectProperty("VentaId", gxTv_SdtVenta_Ventaid, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtVenta_Ventahorafecha;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("VentaHoraFecha", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("SectorId", gxTv_SdtVenta_Sectorid, false, includeNonInitialized);
         AddObjectProperty("EventoId", gxTv_SdtVenta_Eventoid, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtVenta_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtVenta_Initialized, false, includeNonInitialized);
            AddObjectProperty("VentaId_Z", gxTv_SdtVenta_Ventaid_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtVenta_Ventahorafecha_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("VentaHoraFecha_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("SectorId_Z", gxTv_SdtVenta_Sectorid_Z, false, includeNonInitialized);
            AddObjectProperty("EventoId_Z", gxTv_SdtVenta_Eventoid_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtVenta sdt )
      {
         if ( sdt.IsDirty("VentaId") )
         {
            sdtIsNull = 0;
            gxTv_SdtVenta_Ventaid = sdt.gxTv_SdtVenta_Ventaid ;
         }
         if ( sdt.IsDirty("VentaHoraFecha") )
         {
            sdtIsNull = 0;
            gxTv_SdtVenta_Ventahorafecha = sdt.gxTv_SdtVenta_Ventahorafecha ;
         }
         if ( sdt.IsDirty("SectorId") )
         {
            sdtIsNull = 0;
            gxTv_SdtVenta_Sectorid = sdt.gxTv_SdtVenta_Sectorid ;
         }
         if ( sdt.IsDirty("EventoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtVenta_Eventoid = sdt.gxTv_SdtVenta_Eventoid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "VentaId" )]
      [  XmlElement( ElementName = "VentaId"   )]
      public short gxTpr_Ventaid
      {
         get {
            return gxTv_SdtVenta_Ventaid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtVenta_Ventaid != value )
            {
               gxTv_SdtVenta_Mode = "INS";
               this.gxTv_SdtVenta_Ventaid_Z_SetNull( );
               this.gxTv_SdtVenta_Ventahorafecha_Z_SetNull( );
               this.gxTv_SdtVenta_Sectorid_Z_SetNull( );
               this.gxTv_SdtVenta_Eventoid_Z_SetNull( );
            }
            gxTv_SdtVenta_Ventaid = value;
            SetDirty("Ventaid");
         }

      }

      [  SoapElement( ElementName = "VentaHoraFecha" )]
      [  XmlElement( ElementName = "VentaHoraFecha"  , IsNullable=true )]
      public string gxTpr_Ventahorafecha_Nullable
      {
         get {
            if ( gxTv_SdtVenta_Ventahorafecha == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtVenta_Ventahorafecha).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtVenta_Ventahorafecha = DateTime.MinValue;
            else
               gxTv_SdtVenta_Ventahorafecha = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ventahorafecha
      {
         get {
            return gxTv_SdtVenta_Ventahorafecha ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVenta_Ventahorafecha = value;
            SetDirty("Ventahorafecha");
         }

      }

      [  SoapElement( ElementName = "SectorId" )]
      [  XmlElement( ElementName = "SectorId"   )]
      public short gxTpr_Sectorid
      {
         get {
            return gxTv_SdtVenta_Sectorid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVenta_Sectorid = value;
            SetDirty("Sectorid");
         }

      }

      [  SoapElement( ElementName = "EventoId" )]
      [  XmlElement( ElementName = "EventoId"   )]
      public short gxTpr_Eventoid
      {
         get {
            return gxTv_SdtVenta_Eventoid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVenta_Eventoid = value;
            SetDirty("Eventoid");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtVenta_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVenta_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtVenta_Mode_SetNull( )
      {
         gxTv_SdtVenta_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtVenta_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtVenta_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVenta_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtVenta_Initialized_SetNull( )
      {
         gxTv_SdtVenta_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtVenta_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VentaId_Z" )]
      [  XmlElement( ElementName = "VentaId_Z"   )]
      public short gxTpr_Ventaid_Z
      {
         get {
            return gxTv_SdtVenta_Ventaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVenta_Ventaid_Z = value;
            SetDirty("Ventaid_Z");
         }

      }

      public void gxTv_SdtVenta_Ventaid_Z_SetNull( )
      {
         gxTv_SdtVenta_Ventaid_Z = 0;
         SetDirty("Ventaid_Z");
         return  ;
      }

      public bool gxTv_SdtVenta_Ventaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VentaHoraFecha_Z" )]
      [  XmlElement( ElementName = "VentaHoraFecha_Z"  , IsNullable=true )]
      public string gxTpr_Ventahorafecha_Z_Nullable
      {
         get {
            if ( gxTv_SdtVenta_Ventahorafecha_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtVenta_Ventahorafecha_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtVenta_Ventahorafecha_Z = DateTime.MinValue;
            else
               gxTv_SdtVenta_Ventahorafecha_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ventahorafecha_Z
      {
         get {
            return gxTv_SdtVenta_Ventahorafecha_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVenta_Ventahorafecha_Z = value;
            SetDirty("Ventahorafecha_Z");
         }

      }

      public void gxTv_SdtVenta_Ventahorafecha_Z_SetNull( )
      {
         gxTv_SdtVenta_Ventahorafecha_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Ventahorafecha_Z");
         return  ;
      }

      public bool gxTv_SdtVenta_Ventahorafecha_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SectorId_Z" )]
      [  XmlElement( ElementName = "SectorId_Z"   )]
      public short gxTpr_Sectorid_Z
      {
         get {
            return gxTv_SdtVenta_Sectorid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVenta_Sectorid_Z = value;
            SetDirty("Sectorid_Z");
         }

      }

      public void gxTv_SdtVenta_Sectorid_Z_SetNull( )
      {
         gxTv_SdtVenta_Sectorid_Z = 0;
         SetDirty("Sectorid_Z");
         return  ;
      }

      public bool gxTv_SdtVenta_Sectorid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EventoId_Z" )]
      [  XmlElement( ElementName = "EventoId_Z"   )]
      public short gxTpr_Eventoid_Z
      {
         get {
            return gxTv_SdtVenta_Eventoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVenta_Eventoid_Z = value;
            SetDirty("Eventoid_Z");
         }

      }

      public void gxTv_SdtVenta_Eventoid_Z_SetNull( )
      {
         gxTv_SdtVenta_Eventoid_Z = 0;
         SetDirty("Eventoid_Z");
         return  ;
      }

      public bool gxTv_SdtVenta_Eventoid_Z_IsNull( )
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
         gxTv_SdtVenta_Ventahorafecha = (DateTime)(DateTime.MinValue);
         gxTv_SdtVenta_Mode = "";
         gxTv_SdtVenta_Ventahorafecha_Z = (DateTime)(DateTime.MinValue);
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "venta", "GeneXus.Programs.venta_bc", new Object[] {context}, constructorCallingAssembly);;
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

      private short gxTv_SdtVenta_Ventaid ;
      private short sdtIsNull ;
      private short gxTv_SdtVenta_Sectorid ;
      private short gxTv_SdtVenta_Eventoid ;
      private short gxTv_SdtVenta_Initialized ;
      private short gxTv_SdtVenta_Ventaid_Z ;
      private short gxTv_SdtVenta_Sectorid_Z ;
      private short gxTv_SdtVenta_Eventoid_Z ;
      private string gxTv_SdtVenta_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtVenta_Ventahorafecha ;
      private DateTime gxTv_SdtVenta_Ventahorafecha_Z ;
      private DateTime datetime_STZ ;
   }

   [DataContract(Name = @"Venta", Namespace = "TallerGeneXus")]
   [GxJsonSerialization("default")]
   public class SdtVenta_RESTInterface : GxGenericCollectionItem<SdtVenta>
   {
      public SdtVenta_RESTInterface( ) : base()
      {
      }

      public SdtVenta_RESTInterface( SdtVenta psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "VentaId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Ventaid
      {
         get {
            return sdt.gxTpr_Ventaid ;
         }

         set {
            sdt.gxTpr_Ventaid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "VentaHoraFecha" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Ventahorafecha
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Ventahorafecha, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Ventahorafecha = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "SectorId" , Order = 2 )]
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

      public SdtVenta sdt
      {
         get {
            return (SdtVenta)Sdt ;
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
            sdt = new SdtVenta() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 4 )]
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

   [DataContract(Name = @"Venta", Namespace = "TallerGeneXus")]
   [GxJsonSerialization("default")]
   public class SdtVenta_RESTLInterface : GxGenericCollectionItem<SdtVenta>
   {
      public SdtVenta_RESTLInterface( ) : base()
      {
      }

      public SdtVenta_RESTLInterface( SdtVenta psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "VentaHoraFecha" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Ventahorafecha
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Ventahorafecha, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Ventahorafecha = DateTimeUtil.CToT2( value, (IGxContext)(context));
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

      public SdtVenta sdt
      {
         get {
            return (SdtVenta)Sdt ;
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
            sdt = new SdtVenta() ;
         }
      }

   }

}
