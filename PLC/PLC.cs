using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharp7;
using DX.Utilities;

namespace generalPLC
{
    public class PLC
    {


        S7Client Client = new S7Client();
        public static string plcIp = Constants.PLCIP;
        public static string plcRack = Constants.Rack;
        public static string plcSlot = Constants.Slot;



        public int readPlcDbwValue(string plcIp, int Rack, int Slot, int DbNum, int DbwNum)
        {
            byte[] Buffer = new byte[2];
            Client.ConnectTo(plcIp, Rack, Slot);
            Client.DBRead(DbNum, DbwNum, 2, Buffer);//读取DbwNum所对应的字的值
            Client.Disconnect();
            return S7.GetIntAt(Buffer, 0);
        }

        public void writePlcDbwValue(string plcIp, int Rack, int Slot, int DbNum, int DbwNum, int writeValue)
        {
            short a = (short)writeValue;//将整形的writeValue强制转换成short类型
            Client.ConnectTo(plcIp, Rack, Slot);
            byte[] buffer = new byte[2];
            S7.SetIntAt(buffer, 0, a);
            Client.DBWrite(DbNum, DbwNum, 2, buffer);//将DbwNum对应的字更新
            Client.Disconnect();
        }
        public float readPlcDbdValues(string plcIp, int Rack, int Slot, int DbNum, int DbdNum)
        {
            byte[] Buffer = new byte[4];
            Client.ConnectTo(plcIp, Rack, Slot);
            Client.DBRead(DbNum, DbdNum, 4, Buffer);//读取Dbd所对应的值
            Client.Disconnect();
            return S7.GetRealAt(Buffer, 0);
        }
        public void writePlcDbdValue(string plcIp, int Rack, int Slot, int DbNum, int DbdNum, float writeValue)
        {
            short a = (short)writeValue;//将writeValue强制转换成short类型
            Client.ConnectTo(plcIp, Rack, Slot);
            byte[] buffer = new byte[4];
            S7.SetDIntAt(buffer, 0, a);
            Client.DBWrite(DbNum, DbdNum, 4, buffer);//将Dbd更新
            //Client.Disconnect();

        }
        public bool getPlcDbxVaule(string plcIp, int Rack, int Slot, int DbNum, int dbx, int dbxx)
        {
            byte[] Buffer = new byte[1];
            Client.ConnectTo(plcIp, Rack, Slot);
            Client.DBRead(DbNum, dbx, 1, Buffer);//读取Dbx所对应的值      
            Client.Disconnect();
            return S7.GetBitAt(Buffer, 0, dbxx);
        }

        //20200915 添加读取字符串指令
        public string getCharValue(string ip, int dbnum, int start, int size)
        {
            byte[] Buffer = new byte[20];
            Client.ConnectTo(ip, 0, 3);
            Client.DBRead(dbnum, start, size, Buffer);
            Client.Disconnect();
            return S7.GetCharsAt(Buffer, 0, size);
        }


        //20200917 读取M位
        public bool getPlcMX(string plcIp, int start, int size, int pos)
        {
            byte[] Buffer = new byte[1];
            Client.ConnectTo(plcIp, 0, 3);
            Client.MBRead(start, size, Buffer);
            Client.Disconnect();
            return S7.GetBitAt(Buffer, 0, pos);

        }

        //20201026 复制特定字节从一个PLC到另外一个PLC。 S7-400系列PLC默认机架号为0，插槽为3
        public void copyBytes( string ipone,int dbone,int dbonestart,int oneslot, string iptwo, int dbtwo,int dbtwostart,int twoslot, int bytelength)
        {
            byte[] Buffer = new byte[bytelength];
            Client.ConnectTo(ipone, 0, oneslot);
            Client.DBRead(dbone, dbonestart, bytelength, Buffer);      
            Client.Disconnect();
            Client.ConnectTo(iptwo, 0, twoslot);
            Client.DBWrite(dbtwo, dbtwostart, bytelength, Buffer); 
            Client.Disconnect();

        }

        //20201027 读取特定字节

        public byte[] readBytes(string ip,int rack,int slot,int dbnum,int start,int length)
        {
            byte[] Buffer = new byte[length];
            Client.ConnectTo(ip, rack,slot);
            Client.DBRead(dbnum, start, length, Buffer);
            Client.Disconnect();
            return Buffer;
        }


        //20201027写入特定字节
        public void writeBytes(string ip, int rack, int slot, int dbnum, int start, int length,byte[] buffer)
        {
            Client.ConnectTo(ip, rack, slot);
            Client.DBWrite(dbnum, start, length, buffer);
            Client.Disconnect();   
        }



        //20201029 生成DB块字节数组
        public byte[] getDBbytes(string plcIp, int Rack, int Slot, int DbNum, int Start,int Length)
        {
            byte[] Buffer = new byte[Length];
            Client.ConnectTo(plcIp, Rack, Slot);
            Client.DBRead(DbNum, Start, Length, Buffer);//读取DbwNum所对应的字的值
            return Buffer;
        }

        //20201120 读取字符串

        public string getChars(string plcIp,int Rack,int Slot,int DbNum,int Start,int Length)
        {
            byte[] Buffer = new byte[Length];
          if(Client.ConnectTo(plcIp, Rack, Slot)!=0)
            {
                return "PLC连接失败!";
            }
            Client.DBRead(DbNum, Start, Length, Buffer);//读取DbwNum所对应的字的值
            return S7.GetCharsAt(Buffer, Start, Length);
              
        }
        //
        public string getChars(int DbNum, int Start, int Length)
        {
            byte[] Buffer = new byte[Length];
            
            if (Client.ConnectTo(plcIp, Convert.ToInt16(plcRack), Convert.ToInt16(plcSlot)) != 0)
            {
                return "PLC连接失败!";
            }
            Client.DBRead(DbNum, Start, Length, Buffer);//读取DbwNum所对应的字的值
            return S7.GetCharsAt(Buffer, Start, Length);

        }


        //20201120 写入字符串

        public void setChars(string plcIp, int Rack, int Slot, int DbNum, int Start, int Length, string Value)
        {
            byte[] Buffer = new byte[Length];
            Client.ConnectTo(plcIp, Rack, Slot);
            S7.SetCharsAt(Buffer, Start, Value);
            Client.DBWrite(DbNum, Start, Length, Buffer);//将DbwNum对应的字更新
            Client.Disconnect();
        }
        //写入方法重载
        public void setChars(int DbNum, int Start, int Length, string Value)
        {
            byte[] Buffer = new byte[Length];
            Client.ConnectTo(plcIp, Convert.ToInt16(plcRack),Convert.ToInt16(plcSlot));
            S7.SetCharsAt(Buffer, Start, Value);
            Client.DBWrite(DbNum, Start, Length, Buffer);//将DbwNum对应的字更新
            Client.Disconnect();
        }



    }
}
