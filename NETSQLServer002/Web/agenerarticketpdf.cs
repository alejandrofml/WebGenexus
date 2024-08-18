using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class agenerarticketpdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("TallerGeneXus", true);
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "VentaId");
            if ( ! entryPointCalled )
            {
               AV17VentaId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public agenerarticketpdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TallerGeneXus", true);
      }

      public agenerarticketpdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_VentaId )
      {
         this.AV17VentaId = aP0_VentaId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( short aP0_VentaId )
      {
         this.AV17VentaId = aP0_VentaId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         setOutputFileName("Ticket");
         setOutputType("PDF");
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 11909, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            AV9EspectaculoNombre = "";
            AV13LugarNombre = "";
            AV10EventoHoraFecha = DateTimeUtil.Now( context);
            AV19EventoHora = (short)(DateTimeUtil.Hour( DateTimeUtil.Now( context)));
            AV18EventoFecha = DateTimeUtil.ResetTime(DateTimeUtil.Now( context));
            AV16SectorPrecio = 0;
            AV20Fecha = DateTimeUtil.Now( context);
            AV15SectorNombre = "";
            H0H0( false, 53) ;
            getPrinter().GxAttris("Tahoma", 25, true, false, false, false, 0, 0, 0, 0, 1, 255, 192, 203) ;
            getPrinter().GxDrawText("Ticket", 0, Gx_line+0, 827, Gx_line+53, 1, 0, 0, 1) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+53);
            /* Using cursor P000H2 */
            pr_default.execute(0, new Object[] {AV17VentaId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A20SectorCapacidad = P000H2_A20SectorCapacidad[0];
               A21SectorPrecio = P000H2_A21SectorPrecio[0];
               A1EspectaculoId = P000H2_A1EspectaculoId[0];
               A17EventoHoraFecha = P000H2_A17EventoHoraFecha[0];
               A4LugarId = P000H2_A4LugarId[0];
               A10SectorNombre = P000H2_A10SectorNombre[0];
               A8VentaId = P000H2_A8VentaId[0];
               A3EventoId = P000H2_A3EventoId[0];
               A5SectorId = P000H2_A5SectorId[0];
               A1EspectaculoId = P000H2_A1EspectaculoId[0];
               A17EventoHoraFecha = P000H2_A17EventoHoraFecha[0];
               A20SectorCapacidad = P000H2_A20SectorCapacidad[0];
               A21SectorPrecio = P000H2_A21SectorPrecio[0];
               A4LugarId = P000H2_A4LugarId[0];
               A10SectorNombre = P000H2_A10SectorNombre[0];
               AV11EventoId = A3EventoId;
               AV14SectorId = A5SectorId;
               /* Using cursor P000H3 */
               pr_default.execute(1, new Object[] {AV11EventoId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A9LugarNombre = P000H3_A9LugarNombre[0];
                  A14EspectaculoNombre = P000H3_A14EspectaculoNombre[0];
                  A3EventoId = P000H3_A3EventoId[0];
                  A14EspectaculoNombre = P000H3_A14EspectaculoNombre[0];
                  A9LugarNombre = P000H3_A9LugarNombre[0];
                  AV8EspectaculoId = A1EspectaculoId;
                  AV10EventoHoraFecha = A17EventoHoraFecha;
                  AV18EventoFecha = DateTimeUtil.ResetTime( A17EventoHoraFecha);
                  AV19EventoHora = (short)(DateTimeUtil.Hour( A17EventoHoraFecha));
                  AV12LugarId = A4LugarId;
                  AV15SectorNombre = A10SectorNombre;
                  /* Using cursor P000H4 */
                  pr_default.execute(2, new Object[] {AV8EspectaculoId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A1EspectaculoId = P000H4_A1EspectaculoId[0];
                     AV9EspectaculoNombre = A14EspectaculoNombre;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(2);
                  /* Using cursor P000H5 */
                  pr_default.execute(3, new Object[] {AV12LugarId});
                  while ( (pr_default.getStatus(3) != 101) )
                  {
                     A4LugarId = P000H5_A4LugarId[0];
                     AV13LugarNombre = A9LugarNombre;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(3);
                  /* Using cursor P000H6 */
                  pr_default.execute(4, new Object[] {AV14SectorId, A10SectorNombre, A20SectorCapacidad, A21SectorPrecio, A4LugarId});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A5SectorId = P000H6_A5SectorId[0];
                     AV16SectorPrecio = A21SectorPrecio;
                     AV15SectorNombre = A10SectorNombre;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(4);
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(1);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            H0H0( false, 313) ;
            getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Espectaculo:", 47, Gx_line+13, 200, Gx_line+40, 2, 0, 0, 1) ;
            getPrinter().GxAttris("Tahoma", 20, false, false, false, false, 0, 0, 0, 0, 1, 250, 240, 230) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A14EspectaculoNombre, "")), 200, Gx_line+0, 640, Gx_line+53, 1, 0, 0, 1) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A21SectorPrecio), "ZZZ9")), 420, Gx_line+200, 640, Gx_line+227, 1, 0, 0, 1) ;
            getPrinter().GxAttris("Tahoma", 11, false, false, false, false, 0, 0, 0, 0, 1, 255, 228, 225) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV18EventoFecha, "99/99/99"), 200, Gx_line+67, 420, Gx_line+94, 1, 0, 0, 1) ;
            getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Lugar:", 47, Gx_line+107, 200, Gx_line+134, 2, 0, 0, 1) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13LugarNombre, "")), 200, Gx_line+107, 640, Gx_line+134, 1, 0, 0, 1) ;
            getPrinter().GxDrawText("Fecha y hora:", 47, Gx_line+67, 200, Gx_line+94, 2, 0, 0, 1) ;
            getPrinter().GxAttris("Tahoma", 11, false, false, false, false, 0, 0, 0, 0, 1, 255, 228, 225) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV19EventoHora), "ZZZ9")), 420, Gx_line+67, 640, Gx_line+94, 1, 0, 0, 1) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Precio:", 200, Gx_line+200, 420, Gx_line+227, 2, 0, 0, 1) ;
            getPrinter().GxDrawLine(640, Gx_line+0, 640, Gx_line+227, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(200, Gx_line+227, 640, Gx_line+227, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(200, Gx_line+0, 200, Gx_line+227, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(420, Gx_line+200, 640, Gx_line+200, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(420, Gx_line+200, 420, Gx_line+227, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15SectorNombre, "")), 200, Gx_line+147, 640, Gx_line+174, 1, 0, 0, 1) ;
            getPrinter().GxDrawText("Sector:", 47, Gx_line+147, 200, Gx_line+174, 2, 0, 0, 1) ;
            getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV20Fecha, "99/99/99 99:99"), 700, Gx_line+27, 800, Gx_line+54, 1, 0, 0, 1) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Fecha compra:", 700, Gx_line+0, 800, Gx_line+27, 2, 0, 0, 1) ;
            getPrinter().GxDrawLine(700, Gx_line+53, 800, Gx_line+53, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(700, Gx_line+27, 800, Gx_line+27, 1, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+313);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0H0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      protected void H0H0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
         add_metrics1( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Tahoma", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Tahoma", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         if (IsMain)	waitPrinterEnd();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         AV9EspectaculoNombre = "";
         AV13LugarNombre = "";
         AV10EventoHoraFecha = (DateTime)(DateTime.MinValue);
         AV18EventoFecha = DateTime.MinValue;
         AV20Fecha = (DateTime)(DateTime.MinValue);
         AV15SectorNombre = "";
         P000H2_A20SectorCapacidad = new short[1] ;
         P000H2_A21SectorPrecio = new short[1] ;
         P000H2_A1EspectaculoId = new short[1] ;
         P000H2_A17EventoHoraFecha = new DateTime[] {DateTime.MinValue} ;
         P000H2_A4LugarId = new short[1] ;
         P000H2_A10SectorNombre = new string[] {""} ;
         P000H2_A8VentaId = new short[1] ;
         P000H2_A3EventoId = new short[1] ;
         P000H2_A5SectorId = new short[1] ;
         A17EventoHoraFecha = (DateTime)(DateTime.MinValue);
         A10SectorNombre = "";
         P000H3_A1EspectaculoId = new short[1] ;
         P000H3_A4LugarId = new short[1] ;
         P000H3_A9LugarNombre = new string[] {""} ;
         P000H3_A14EspectaculoNombre = new string[] {""} ;
         P000H3_A3EventoId = new short[1] ;
         A9LugarNombre = "";
         A14EspectaculoNombre = "";
         P000H4_A1EspectaculoId = new short[1] ;
         P000H5_A4LugarId = new short[1] ;
         P000H6_A10SectorNombre = new string[] {""} ;
         P000H6_A20SectorCapacidad = new short[1] ;
         P000H6_A21SectorPrecio = new short[1] ;
         P000H6_A4LugarId = new short[1] ;
         P000H6_A5SectorId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.agenerarticketpdf__default(),
            new Object[][] {
                new Object[] {
               P000H2_A20SectorCapacidad, P000H2_A21SectorPrecio, P000H2_A1EspectaculoId, P000H2_A17EventoHoraFecha, P000H2_A4LugarId, P000H2_A10SectorNombre, P000H2_A8VentaId, P000H2_A3EventoId, P000H2_A5SectorId
               }
               , new Object[] {
               P000H3_A1EspectaculoId, P000H3_A4LugarId, P000H3_A9LugarNombre, P000H3_A14EspectaculoNombre, P000H3_A3EventoId
               }
               , new Object[] {
               P000H4_A1EspectaculoId
               }
               , new Object[] {
               P000H5_A4LugarId
               }
               , new Object[] {
               P000H6_A10SectorNombre, P000H6_A20SectorCapacidad, P000H6_A21SectorPrecio, P000H6_A4LugarId, P000H6_A5SectorId
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV17VentaId ;
      private short GxWebError ;
      private short AV19EventoHora ;
      private short AV16SectorPrecio ;
      private short A20SectorCapacidad ;
      private short A21SectorPrecio ;
      private short A1EspectaculoId ;
      private short A4LugarId ;
      private short A8VentaId ;
      private short A3EventoId ;
      private short A5SectorId ;
      private short AV11EventoId ;
      private short AV14SectorId ;
      private short AV8EspectaculoId ;
      private short AV12LugarId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private DateTime AV10EventoHoraFecha ;
      private DateTime AV20Fecha ;
      private DateTime A17EventoHoraFecha ;
      private DateTime AV18EventoFecha ;
      private bool entryPointCalled ;
      private string AV9EspectaculoNombre ;
      private string AV13LugarNombre ;
      private string AV15SectorNombre ;
      private string A10SectorNombre ;
      private string A9LugarNombre ;
      private string A14EspectaculoNombre ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000H2_A20SectorCapacidad ;
      private short[] P000H2_A21SectorPrecio ;
      private short[] P000H2_A1EspectaculoId ;
      private DateTime[] P000H2_A17EventoHoraFecha ;
      private short[] P000H2_A4LugarId ;
      private string[] P000H2_A10SectorNombre ;
      private short[] P000H2_A8VentaId ;
      private short[] P000H2_A3EventoId ;
      private short[] P000H2_A5SectorId ;
      private short[] P000H3_A1EspectaculoId ;
      private short[] P000H3_A4LugarId ;
      private string[] P000H3_A9LugarNombre ;
      private string[] P000H3_A14EspectaculoNombre ;
      private short[] P000H3_A3EventoId ;
      private short[] P000H4_A1EspectaculoId ;
      private short[] P000H5_A4LugarId ;
      private string[] P000H6_A10SectorNombre ;
      private short[] P000H6_A20SectorCapacidad ;
      private short[] P000H6_A21SectorPrecio ;
      private short[] P000H6_A4LugarId ;
      private short[] P000H6_A5SectorId ;
   }

   public class agenerarticketpdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000H2;
          prmP000H2 = new Object[] {
          new ParDef("@AV17VentaId",GXType.Int16,4,0)
          };
          Object[] prmP000H3;
          prmP000H3 = new Object[] {
          new ParDef("@AV11EventoId",GXType.Int16,4,0)
          };
          Object[] prmP000H4;
          prmP000H4 = new Object[] {
          new ParDef("@AV8EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmP000H5;
          prmP000H5 = new Object[] {
          new ParDef("@AV12LugarId",GXType.Int16,4,0)
          };
          Object[] prmP000H6;
          prmP000H6 = new Object[] {
          new ParDef("@AV14SectorId",GXType.Int16,4,0) ,
          new ParDef("@SectorNombre",GXType.NVarChar,100,0) ,
          new ParDef("@SectorCapacidad",GXType.Int16,4,0) ,
          new ParDef("@SectorPrecio",GXType.Int16,4,0) ,
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000H2", "SELECT T3.[SectorCapacidad], T3.[SectorPrecio], T2.[EspectaculoId], T2.[EventoHoraFecha], T3.[LugarId], T3.[SectorNombre], T1.[VentaId], T1.[EventoId], T1.[SectorId] FROM (([Venta] T1 INNER JOIN [Evento] T2 ON T2.[EventoId] = T1.[EventoId]) INNER JOIN [Sector] T3 ON T3.[SectorId] = T1.[SectorId]) WHERE T1.[VentaId] = @AV17VentaId ORDER BY T1.[VentaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000H2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P000H3", "SELECT T1.[EspectaculoId], T1.[LugarId], T3.[LugarNombre], T2.[EspectaculoNombre], T1.[EventoId] FROM (([Evento] T1 INNER JOIN [Espectaculo] T2 ON T2.[EspectaculoId] = T1.[EspectaculoId]) INNER JOIN [Lugar] T3 ON T3.[LugarId] = T1.[LugarId]) WHERE T1.[EventoId] = @AV11EventoId ORDER BY T1.[EventoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000H3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P000H4", "SELECT [EspectaculoId] FROM [Espectaculo] WHERE [EspectaculoId] = @AV8EspectaculoId ORDER BY [EspectaculoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000H4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P000H5", "SELECT [LugarId] FROM [Lugar] WHERE [LugarId] = @AV12LugarId ORDER BY [LugarId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000H5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P000H6", "SELECT [SectorNombre], [SectorCapacidad], [SectorPrecio], [LugarId], [SectorId] FROM [Sector] WHERE ([SectorId] = @AV14SectorId) AND ([SectorNombre] = @SectorNombre) AND ([SectorCapacidad] = @SectorCapacidad) AND ([SectorPrecio] = @SectorPrecio) AND ([LugarId] = @LugarId) ORDER BY [SectorId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000H6,1, GxCacheFrequency.OFF ,false,true )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
       }
    }

 }

}
