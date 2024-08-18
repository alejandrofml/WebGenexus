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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class lugar_dataprovider : GXProcedure
   {
      public lugar_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TallerGeneXus", true);
      }

      public lugar_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBCCollection<SdtLugar> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtLugar>( context, "Lugar", "TallerGeneXus") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<SdtLugar> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<SdtLugar> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtLugar>( context, "Lugar", "TallerGeneXus") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00033 */
         pr_default.execute(0);
         if ( (pr_default.getStatus(0) != 101) )
         {
            A40000PaisId = P00033_A40000PaisId[0];
            n40000PaisId = P00033_n40000PaisId[0];
         }
         else
         {
            A40000PaisId = 0;
            n40000PaisId = false;
         }
         pr_default.close(0);
         /* Using cursor P00035 */
         pr_default.execute(1);
         if ( (pr_default.getStatus(1) != 101) )
         {
            A40001PaisId = P00035_A40001PaisId[0];
            n40001PaisId = P00035_n40001PaisId[0];
         }
         else
         {
            A40001PaisId = 0;
            n40001PaisId = false;
         }
         pr_default.close(1);
         /* Using cursor P00037 */
         pr_default.execute(2);
         if ( (pr_default.getStatus(2) != 101) )
         {
            A40002PaisId = P00037_A40002PaisId[0];
            n40002PaisId = P00037_n40002PaisId[0];
         }
         else
         {
            A40002PaisId = 0;
            n40002PaisId = false;
         }
         pr_default.close(2);
         /* Using cursor P00039 */
         pr_default.execute(3);
         if ( (pr_default.getStatus(3) != 101) )
         {
            A40003PaisId = P00039_A40003PaisId[0];
            n40003PaisId = P00039_n40003PaisId[0];
         }
         else
         {
            A40003PaisId = 0;
            n40003PaisId = false;
         }
         pr_default.close(3);
         /* Using cursor P000311 */
         pr_default.execute(4);
         if ( (pr_default.getStatus(4) != 101) )
         {
            A40004PaisId = P000311_A40004PaisId[0];
            n40004PaisId = P000311_n40004PaisId[0];
         }
         else
         {
            A40004PaisId = 0;
            n40004PaisId = false;
         }
         pr_default.close(4);
         Gxm1lugar = new SdtLugar(context);
         Gxm2rootcol.Add(Gxm1lugar, 0);
         Gxm1lugar.gxTpr_Lugarnombre = "Estadio Centenario";
         Gxm1lugar.gxTpr_Lugardireccion = "Montevideo, Uruguay";
         Gxm1lugar.gxTpr_Paisid = A40000PaisId;
         Gxm1lugar = new SdtLugar(context);
         Gxm2rootcol.Add(Gxm1lugar, 0);
         Gxm1lugar.gxTpr_Lugarnombre = "Estadio Nacional";
         Gxm1lugar.gxTpr_Lugardireccion = "Santiago, Chile";
         Gxm1lugar.gxTpr_Paisid = A40001PaisId;
         Gxm1lugar = new SdtLugar(context);
         Gxm2rootcol.Add(Gxm1lugar, 0);
         Gxm1lugar.gxTpr_Lugarnombre = "Sodre";
         Gxm1lugar.gxTpr_Lugardireccion = "Montevideo, Uruguay";
         Gxm1lugar.gxTpr_Paisid = A40000PaisId;
         Gxm1lugar = new SdtLugar(context);
         Gxm2rootcol.Add(Gxm1lugar, 0);
         Gxm1lugar.gxTpr_Lugarnombre = "Luna Park";
         Gxm1lugar.gxTpr_Lugardireccion = "Buenos Aires, Argentina";
         Gxm1lugar.gxTpr_Paisid = A40002PaisId;
         Gxm1lugar = new SdtLugar(context);
         Gxm2rootcol.Add(Gxm1lugar, 0);
         Gxm1lugar.gxTpr_Lugarnombre = "Teatro Solís";
         Gxm1lugar.gxTpr_Lugardireccion = "Montevideo, Uruguay";
         Gxm1lugar.gxTpr_Paisid = A40000PaisId;
         Gxm1lugar = new SdtLugar(context);
         Gxm2rootcol.Add(Gxm1lugar, 0);
         Gxm1lugar.gxTpr_Lugarnombre = "Teatro Colón";
         Gxm1lugar.gxTpr_Lugardireccion = "Buenos Aires, Argentina";
         Gxm1lugar.gxTpr_Paisid = A40002PaisId;
         Gxm1lugar = new SdtLugar(context);
         Gxm2rootcol.Add(Gxm1lugar, 0);
         Gxm1lugar.gxTpr_Lugarnombre = "Auditorio Nacional";
         Gxm1lugar.gxTpr_Lugardireccion = "Ciudad de México, México";
         Gxm1lugar.gxTpr_Paisid = A40003PaisId;
         Gxm1lugar = new SdtLugar(context);
         Gxm2rootcol.Add(Gxm1lugar, 0);
         Gxm1lugar.gxTpr_Lugarnombre = "Teatro Sao Pedro";
         Gxm1lugar.gxTpr_Lugardireccion = "São Paulo, Brasil";
         Gxm1lugar.gxTpr_Paisid = A40004PaisId;
         Gxm1lugar = new SdtLugar(context);
         Gxm2rootcol.Add(Gxm1lugar, 0);
         Gxm1lugar.gxTpr_Lugarnombre = "Municipal de Santiago";
         Gxm1lugar.gxTpr_Lugardireccion = "Santiago, Chile";
         Gxm1lugar.gxTpr_Paisid = A40001PaisId;
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P00033_A40000PaisId = new short[1] ;
         P00033_n40000PaisId = new bool[] {false} ;
         P00035_A40001PaisId = new short[1] ;
         P00035_n40001PaisId = new bool[] {false} ;
         P00037_A40002PaisId = new short[1] ;
         P00037_n40002PaisId = new bool[] {false} ;
         P00039_A40003PaisId = new short[1] ;
         P00039_n40003PaisId = new bool[] {false} ;
         P000311_A40004PaisId = new short[1] ;
         P000311_n40004PaisId = new bool[] {false} ;
         Gxm1lugar = new SdtLugar(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.lugar_dataprovider__default(),
            new Object[][] {
                new Object[] {
               P00033_A40000PaisId, P00033_n40000PaisId
               }
               , new Object[] {
               P00035_A40001PaisId, P00035_n40001PaisId
               }
               , new Object[] {
               P00037_A40002PaisId, P00037_n40002PaisId
               }
               , new Object[] {
               P00039_A40003PaisId, P00039_n40003PaisId
               }
               , new Object[] {
               P000311_A40004PaisId, P000311_n40004PaisId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A40000PaisId ;
      private short A40001PaisId ;
      private short A40002PaisId ;
      private short A40003PaisId ;
      private short A40004PaisId ;
      private bool n40000PaisId ;
      private bool n40001PaisId ;
      private bool n40002PaisId ;
      private bool n40003PaisId ;
      private bool n40004PaisId ;
      private IGxDataStore dsDefault ;
      private GXBCCollection<SdtLugar> Gxm2rootcol ;
      private IDataStoreProvider pr_default ;
      private short[] P00033_A40000PaisId ;
      private bool[] P00033_n40000PaisId ;
      private short[] P00035_A40001PaisId ;
      private bool[] P00035_n40001PaisId ;
      private short[] P00037_A40002PaisId ;
      private bool[] P00037_n40002PaisId ;
      private short[] P00039_A40003PaisId ;
      private bool[] P00039_n40003PaisId ;
      private short[] P000311_A40004PaisId ;
      private bool[] P000311_n40004PaisId ;
      private SdtLugar Gxm1lugar ;
      private GXBCCollection<SdtLugar> aP0_Gxm2rootcol ;
   }

   public class lugar_dataprovider__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00033;
          prmP00033 = new Object[] {
          };
          Object[] prmP00035;
          prmP00035 = new Object[] {
          };
          Object[] prmP00037;
          prmP00037 = new Object[] {
          };
          Object[] prmP00039;
          prmP00039 = new Object[] {
          };
          Object[] prmP000311;
          prmP000311 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00033", "SELECT COALESCE( T1.[PaisId], 0) AS PaisId FROM (SELECT MIN([PaisId]) AS PaisId FROM [Pais] WHERE [PaisNombre] = 'Uruguay' ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00033,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00035", "SELECT COALESCE( T1.[PaisId], 0) AS PaisId FROM (SELECT MIN([PaisId]) AS PaisId FROM [Pais] WHERE [PaisNombre] = 'Chile' ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00035,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00037", "SELECT COALESCE( T1.[PaisId], 0) AS PaisId FROM (SELECT MIN([PaisId]) AS PaisId FROM [Pais] WHERE [PaisNombre] = 'Argentina' ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00037,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00039", "SELECT COALESCE( T1.[PaisId], 0) AS PaisId FROM (SELECT MIN([PaisId]) AS PaisId FROM [Pais] WHERE [PaisNombre] = 'México' ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00039,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000311", "SELECT COALESCE( T1.[PaisId], 0) AS PaisId FROM (SELECT MIN([PaisId]) AS PaisId FROM [Pais] WHERE [PaisNombre] = 'Brasil' ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000311,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

 }

}
