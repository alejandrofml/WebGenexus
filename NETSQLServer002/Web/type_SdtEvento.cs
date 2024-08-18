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
   [XmlRoot(ElementName = "Evento" )]
   [XmlType(TypeName =  "Evento" , Namespace = "TallerGeneXus" )]
   [Serializable]
   public class SdtEvento : GxSilentTrnSdt
   {
      public SdtEvento( )
      {
      }

      public SdtEvento( IGxContext context )
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

      public void Load( short AV3EventoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV3EventoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"EventoId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Evento");
         metadata.Set("BT", "Evento");
         metadata.Set("PK", "[ \"EventoId\" ]");
         metadata.Set("PKAssigned", "[ \"EventoId\" ]");
         metadata.Set("Levels", "[ \"Invitaciones\",\"Sectores\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"EspectaculoId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"LugarId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Eventoid_Z");
         state.Add("gxTpr_Eventohorafecha_Z_Nullable");
         state.Add("gxTpr_Espectaculoid_Z");
         state.Add("gxTpr_Lugarid_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtEvento sdt;
         sdt = (SdtEvento)(source);
         gxTv_SdtEvento_Eventoid = sdt.gxTv_SdtEvento_Eventoid ;
         gxTv_SdtEvento_Eventohorafecha = sdt.gxTv_SdtEvento_Eventohorafecha ;
         gxTv_SdtEvento_Espectaculoid = sdt.gxTv_SdtEvento_Espectaculoid ;
         gxTv_SdtEvento_Lugarid = sdt.gxTv_SdtEvento_Lugarid ;
         gxTv_SdtEvento_Sectores = sdt.gxTv_SdtEvento_Sectores ;
         gxTv_SdtEvento_Invitaciones = sdt.gxTv_SdtEvento_Invitaciones ;
         gxTv_SdtEvento_Mode = sdt.gxTv_SdtEvento_Mode ;
         gxTv_SdtEvento_Initialized = sdt.gxTv_SdtEvento_Initialized ;
         gxTv_SdtEvento_Eventoid_Z = sdt.gxTv_SdtEvento_Eventoid_Z ;
         gxTv_SdtEvento_Eventohorafecha_Z = sdt.gxTv_SdtEvento_Eventohorafecha_Z ;
         gxTv_SdtEvento_Espectaculoid_Z = sdt.gxTv_SdtEvento_Espectaculoid_Z ;
         gxTv_SdtEvento_Lugarid_Z = sdt.gxTv_SdtEvento_Lugarid_Z ;
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
         AddObjectProperty("EventoId", gxTv_SdtEvento_Eventoid, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtEvento_Eventohorafecha;
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
         AddObjectProperty("EventoHoraFecha", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("EspectaculoId", gxTv_SdtEvento_Espectaculoid, false, includeNonInitialized);
         AddObjectProperty("LugarId", gxTv_SdtEvento_Lugarid, false, includeNonInitialized);
         if ( gxTv_SdtEvento_Sectores != null )
         {
            AddObjectProperty("Sectores", gxTv_SdtEvento_Sectores, includeState, includeNonInitialized);
         }
         if ( gxTv_SdtEvento_Invitaciones != null )
         {
            AddObjectProperty("Invitaciones", gxTv_SdtEvento_Invitaciones, includeState, includeNonInitialized);
         }
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtEvento_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtEvento_Initialized, false, includeNonInitialized);
            AddObjectProperty("EventoId_Z", gxTv_SdtEvento_Eventoid_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtEvento_Eventohorafecha_Z;
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
            AddObjectProperty("EventoHoraFecha_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("EspectaculoId_Z", gxTv_SdtEvento_Espectaculoid_Z, false, includeNonInitialized);
            AddObjectProperty("LugarId_Z", gxTv_SdtEvento_Lugarid_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtEvento sdt )
      {
         if ( sdt.IsDirty("EventoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtEvento_Eventoid = sdt.gxTv_SdtEvento_Eventoid ;
         }
         if ( sdt.IsDirty("EventoHoraFecha") )
         {
            sdtIsNull = 0;
            gxTv_SdtEvento_Eventohorafecha = sdt.gxTv_SdtEvento_Eventohorafecha ;
         }
         if ( sdt.IsDirty("EspectaculoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtEvento_Espectaculoid = sdt.gxTv_SdtEvento_Espectaculoid ;
         }
         if ( sdt.IsDirty("LugarId") )
         {
            sdtIsNull = 0;
            gxTv_SdtEvento_Lugarid = sdt.gxTv_SdtEvento_Lugarid ;
         }
         if ( gxTv_SdtEvento_Sectores != null )
         {
            GXBCLevelCollection<SdtEvento_Sectores> newCollectionSectores = sdt.gxTpr_Sectores;
            SdtEvento_Sectores currItemSectores;
            SdtEvento_Sectores newItemSectores;
            short idx = 1;
            while ( idx <= newCollectionSectores.Count )
            {
               newItemSectores = ((SdtEvento_Sectores)newCollectionSectores.Item(idx));
               currItemSectores = gxTv_SdtEvento_Sectores.GetByKey(newItemSectores.gxTpr_Sectorid);
               if ( StringUtil.StrCmp(currItemSectores.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemSectores.UpdateDirties(newItemSectores);
                  if ( StringUtil.StrCmp(newItemSectores.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemSectores.gxTpr_Mode = "DLT";
                  }
                  currItemSectores.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtEvento_Sectores.Add(newItemSectores, 0);
               }
               idx = (short)(idx+1);
            }
         }
         if ( gxTv_SdtEvento_Invitaciones != null )
         {
            GXBCLevelCollection<SdtEvento_Invitaciones> newCollectionInvitaciones = sdt.gxTpr_Invitaciones;
            SdtEvento_Invitaciones currItemInvitaciones;
            SdtEvento_Invitaciones newItemInvitaciones;
            short idx = 1;
            while ( idx <= newCollectionInvitaciones.Count )
            {
               newItemInvitaciones = ((SdtEvento_Invitaciones)newCollectionInvitaciones.Item(idx));
               currItemInvitaciones = gxTv_SdtEvento_Invitaciones.GetByKey(newItemInvitaciones.gxTpr_Invitacionid);
               if ( StringUtil.StrCmp(currItemInvitaciones.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemInvitaciones.UpdateDirties(newItemInvitaciones);
                  if ( StringUtil.StrCmp(newItemInvitaciones.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemInvitaciones.gxTpr_Mode = "DLT";
                  }
                  currItemInvitaciones.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtEvento_Invitaciones.Add(newItemInvitaciones, 0);
               }
               idx = (short)(idx+1);
            }
         }
         return  ;
      }

      [  SoapElement( ElementName = "EventoId" )]
      [  XmlElement( ElementName = "EventoId"   )]
      public short gxTpr_Eventoid
      {
         get {
            return gxTv_SdtEvento_Eventoid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtEvento_Eventoid != value )
            {
               gxTv_SdtEvento_Mode = "INS";
               this.gxTv_SdtEvento_Eventoid_Z_SetNull( );
               this.gxTv_SdtEvento_Eventohorafecha_Z_SetNull( );
               this.gxTv_SdtEvento_Espectaculoid_Z_SetNull( );
               this.gxTv_SdtEvento_Lugarid_Z_SetNull( );
               if ( gxTv_SdtEvento_Sectores != null )
               {
                  GXBCLevelCollection<SdtEvento_Sectores> collectionSectores = gxTv_SdtEvento_Sectores;
                  SdtEvento_Sectores currItemSectores;
                  short idx = 1;
                  while ( idx <= collectionSectores.Count )
                  {
                     currItemSectores = ((SdtEvento_Sectores)collectionSectores.Item(idx));
                     currItemSectores.gxTpr_Mode = "INS";
                     currItemSectores.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
               if ( gxTv_SdtEvento_Invitaciones != null )
               {
                  GXBCLevelCollection<SdtEvento_Invitaciones> collectionInvitaciones = gxTv_SdtEvento_Invitaciones;
                  SdtEvento_Invitaciones currItemInvitaciones;
                  short idx = 1;
                  while ( idx <= collectionInvitaciones.Count )
                  {
                     currItemInvitaciones = ((SdtEvento_Invitaciones)collectionInvitaciones.Item(idx));
                     currItemInvitaciones.gxTpr_Mode = "INS";
                     currItemInvitaciones.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtEvento_Eventoid = value;
            SetDirty("Eventoid");
         }

      }

      [  SoapElement( ElementName = "EventoHoraFecha" )]
      [  XmlElement( ElementName = "EventoHoraFecha"  , IsNullable=true )]
      public string gxTpr_Eventohorafecha_Nullable
      {
         get {
            if ( gxTv_SdtEvento_Eventohorafecha == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtEvento_Eventohorafecha).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtEvento_Eventohorafecha = DateTime.MinValue;
            else
               gxTv_SdtEvento_Eventohorafecha = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Eventohorafecha
      {
         get {
            return gxTv_SdtEvento_Eventohorafecha ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEvento_Eventohorafecha = value;
            SetDirty("Eventohorafecha");
         }

      }

      [  SoapElement( ElementName = "EspectaculoId" )]
      [  XmlElement( ElementName = "EspectaculoId"   )]
      public short gxTpr_Espectaculoid
      {
         get {
            return gxTv_SdtEvento_Espectaculoid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEvento_Espectaculoid = value;
            SetDirty("Espectaculoid");
         }

      }

      [  SoapElement( ElementName = "LugarId" )]
      [  XmlElement( ElementName = "LugarId"   )]
      public short gxTpr_Lugarid
      {
         get {
            return gxTv_SdtEvento_Lugarid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEvento_Lugarid = value;
            SetDirty("Lugarid");
         }

      }

      [  SoapElement( ElementName = "Sectores" )]
      [  XmlArray( ElementName = "Sectores"  )]
      [  XmlArrayItemAttribute( ElementName= "Evento.Sectores"  , IsNullable=false)]
      public GXBCLevelCollection<SdtEvento_Sectores> gxTpr_Sectores_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtEvento_Sectores == null )
            {
               gxTv_SdtEvento_Sectores = new GXBCLevelCollection<SdtEvento_Sectores>( context, "Evento.Sectores", "TallerGeneXus");
            }
            return gxTv_SdtEvento_Sectores ;
         }

         set {
            if ( gxTv_SdtEvento_Sectores == null )
            {
               gxTv_SdtEvento_Sectores = new GXBCLevelCollection<SdtEvento_Sectores>( context, "Evento.Sectores", "TallerGeneXus");
            }
            sdtIsNull = 0;
            gxTv_SdtEvento_Sectores = value;
         }

      }

      [XmlIgnore]
      public GXBCLevelCollection<SdtEvento_Sectores> gxTpr_Sectores
      {
         get {
            if ( gxTv_SdtEvento_Sectores == null )
            {
               gxTv_SdtEvento_Sectores = new GXBCLevelCollection<SdtEvento_Sectores>( context, "Evento.Sectores", "TallerGeneXus");
            }
            sdtIsNull = 0;
            return gxTv_SdtEvento_Sectores ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEvento_Sectores = value;
            SetDirty("Sectores");
         }

      }

      public void gxTv_SdtEvento_Sectores_SetNull( )
      {
         gxTv_SdtEvento_Sectores = null;
         SetDirty("Sectores");
         return  ;
      }

      public bool gxTv_SdtEvento_Sectores_IsNull( )
      {
         if ( gxTv_SdtEvento_Sectores == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Invitaciones" )]
      [  XmlArray( ElementName = "Invitaciones"  )]
      [  XmlArrayItemAttribute( ElementName= "Evento.Invitaciones"  , IsNullable=false)]
      public GXBCLevelCollection<SdtEvento_Invitaciones> gxTpr_Invitaciones_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtEvento_Invitaciones == null )
            {
               gxTv_SdtEvento_Invitaciones = new GXBCLevelCollection<SdtEvento_Invitaciones>( context, "Evento.Invitaciones", "TallerGeneXus");
            }
            return gxTv_SdtEvento_Invitaciones ;
         }

         set {
            if ( gxTv_SdtEvento_Invitaciones == null )
            {
               gxTv_SdtEvento_Invitaciones = new GXBCLevelCollection<SdtEvento_Invitaciones>( context, "Evento.Invitaciones", "TallerGeneXus");
            }
            sdtIsNull = 0;
            gxTv_SdtEvento_Invitaciones = value;
         }

      }

      [XmlIgnore]
      public GXBCLevelCollection<SdtEvento_Invitaciones> gxTpr_Invitaciones
      {
         get {
            if ( gxTv_SdtEvento_Invitaciones == null )
            {
               gxTv_SdtEvento_Invitaciones = new GXBCLevelCollection<SdtEvento_Invitaciones>( context, "Evento.Invitaciones", "TallerGeneXus");
            }
            sdtIsNull = 0;
            return gxTv_SdtEvento_Invitaciones ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEvento_Invitaciones = value;
            SetDirty("Invitaciones");
         }

      }

      public void gxTv_SdtEvento_Invitaciones_SetNull( )
      {
         gxTv_SdtEvento_Invitaciones = null;
         SetDirty("Invitaciones");
         return  ;
      }

      public bool gxTv_SdtEvento_Invitaciones_IsNull( )
      {
         if ( gxTv_SdtEvento_Invitaciones == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtEvento_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEvento_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtEvento_Mode_SetNull( )
      {
         gxTv_SdtEvento_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtEvento_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtEvento_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEvento_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtEvento_Initialized_SetNull( )
      {
         gxTv_SdtEvento_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtEvento_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EventoId_Z" )]
      [  XmlElement( ElementName = "EventoId_Z"   )]
      public short gxTpr_Eventoid_Z
      {
         get {
            return gxTv_SdtEvento_Eventoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEvento_Eventoid_Z = value;
            SetDirty("Eventoid_Z");
         }

      }

      public void gxTv_SdtEvento_Eventoid_Z_SetNull( )
      {
         gxTv_SdtEvento_Eventoid_Z = 0;
         SetDirty("Eventoid_Z");
         return  ;
      }

      public bool gxTv_SdtEvento_Eventoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EventoHoraFecha_Z" )]
      [  XmlElement( ElementName = "EventoHoraFecha_Z"  , IsNullable=true )]
      public string gxTpr_Eventohorafecha_Z_Nullable
      {
         get {
            if ( gxTv_SdtEvento_Eventohorafecha_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtEvento_Eventohorafecha_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtEvento_Eventohorafecha_Z = DateTime.MinValue;
            else
               gxTv_SdtEvento_Eventohorafecha_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Eventohorafecha_Z
      {
         get {
            return gxTv_SdtEvento_Eventohorafecha_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEvento_Eventohorafecha_Z = value;
            SetDirty("Eventohorafecha_Z");
         }

      }

      public void gxTv_SdtEvento_Eventohorafecha_Z_SetNull( )
      {
         gxTv_SdtEvento_Eventohorafecha_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Eventohorafecha_Z");
         return  ;
      }

      public bool gxTv_SdtEvento_Eventohorafecha_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspectaculoId_Z" )]
      [  XmlElement( ElementName = "EspectaculoId_Z"   )]
      public short gxTpr_Espectaculoid_Z
      {
         get {
            return gxTv_SdtEvento_Espectaculoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEvento_Espectaculoid_Z = value;
            SetDirty("Espectaculoid_Z");
         }

      }

      public void gxTv_SdtEvento_Espectaculoid_Z_SetNull( )
      {
         gxTv_SdtEvento_Espectaculoid_Z = 0;
         SetDirty("Espectaculoid_Z");
         return  ;
      }

      public bool gxTv_SdtEvento_Espectaculoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LugarId_Z" )]
      [  XmlElement( ElementName = "LugarId_Z"   )]
      public short gxTpr_Lugarid_Z
      {
         get {
            return gxTv_SdtEvento_Lugarid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEvento_Lugarid_Z = value;
            SetDirty("Lugarid_Z");
         }

      }

      public void gxTv_SdtEvento_Lugarid_Z_SetNull( )
      {
         gxTv_SdtEvento_Lugarid_Z = 0;
         SetDirty("Lugarid_Z");
         return  ;
      }

      public bool gxTv_SdtEvento_Lugarid_Z_IsNull( )
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
         gxTv_SdtEvento_Eventohorafecha = (DateTime)(DateTime.MinValue);
         gxTv_SdtEvento_Mode = "";
         gxTv_SdtEvento_Eventohorafecha_Z = (DateTime)(DateTime.MinValue);
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "evento", "GeneXus.Programs.evento_bc", new Object[] {context}, constructorCallingAssembly);;
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

      private short gxTv_SdtEvento_Eventoid ;
      private short sdtIsNull ;
      private short gxTv_SdtEvento_Espectaculoid ;
      private short gxTv_SdtEvento_Lugarid ;
      private short gxTv_SdtEvento_Initialized ;
      private short gxTv_SdtEvento_Eventoid_Z ;
      private short gxTv_SdtEvento_Espectaculoid_Z ;
      private short gxTv_SdtEvento_Lugarid_Z ;
      private string gxTv_SdtEvento_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtEvento_Eventohorafecha ;
      private DateTime gxTv_SdtEvento_Eventohorafecha_Z ;
      private DateTime datetime_STZ ;
      private GXBCLevelCollection<SdtEvento_Sectores> gxTv_SdtEvento_Sectores=null ;
      private GXBCLevelCollection<SdtEvento_Invitaciones> gxTv_SdtEvento_Invitaciones=null ;
   }

   [DataContract(Name = @"Evento", Namespace = "TallerGeneXus")]
   [GxJsonSerialization("default")]
   public class SdtEvento_RESTInterface : GxGenericCollectionItem<SdtEvento>
   {
      public SdtEvento_RESTInterface( ) : base()
      {
      }

      public SdtEvento_RESTInterface( SdtEvento psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EventoId" , Order = 0 )]
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

      [DataMember( Name = "EventoHoraFecha" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Eventohorafecha
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Eventohorafecha, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Eventohorafecha = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "EspectaculoId" , Order = 2 )]
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

      [DataMember( Name = "LugarId" , Order = 3 )]
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

      [DataMember( Name = "Sectores" , Order = 4 )]
      public GxGenericCollection<SdtEvento_Sectores_RESTInterface> gxTpr_Sectores
      {
         get {
            return new GxGenericCollection<SdtEvento_Sectores_RESTInterface>(sdt.gxTpr_Sectores) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Sectores);
         }

      }

      [DataMember( Name = "Invitaciones" , Order = 5 )]
      public GxGenericCollection<SdtEvento_Invitaciones_RESTInterface> gxTpr_Invitaciones
      {
         get {
            return new GxGenericCollection<SdtEvento_Invitaciones_RESTInterface>(sdt.gxTpr_Invitaciones) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Invitaciones);
         }

      }

      public SdtEvento sdt
      {
         get {
            return (SdtEvento)Sdt ;
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
            sdt = new SdtEvento() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 6 )]
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

   [DataContract(Name = @"Evento", Namespace = "TallerGeneXus")]
   [GxJsonSerialization("default")]
   public class SdtEvento_RESTLInterface : GxGenericCollectionItem<SdtEvento>
   {
      public SdtEvento_RESTLInterface( ) : base()
      {
      }

      public SdtEvento_RESTLInterface( SdtEvento psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EventoHoraFecha" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Eventohorafecha
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Eventohorafecha, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Eventohorafecha = DateTimeUtil.CToT2( value, (IGxContext)(context));
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

      public SdtEvento sdt
      {
         get {
            return (SdtEvento)Sdt ;
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
            sdt = new SdtEvento() ;
         }
      }

   }

}
