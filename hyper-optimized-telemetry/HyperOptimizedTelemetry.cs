using System;
using System.Linq;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        byte[] buffer = new byte[9];
        switch (reading)
        {
            //ushort
            case >= 0 and <= 65_535:
                buffer[0] = 2;
                BitConverter.GetBytes((ushort)reading).CopyTo(buffer, 1);
                break;
            //short
            case >= -32_768 and <= -1:
                buffer[0] = (byte)(256 - 2);
                BitConverter.GetBytes((short)reading).CopyTo(buffer, 1);
                break;
            //int
            case >= 65_536 and <= 2_147_483_647:
                buffer[0] = (byte)(256 - 4);
                BitConverter.GetBytes((int)reading).CopyTo(buffer, 1);
                break;
            //int
            case >= -2_147_483_648 and <= -31_769:
                buffer[0] = (byte)(256 - 4);
                BitConverter.GetBytes((int)reading).CopyTo(buffer, 1);
                break;
            //uint
            case >= 2_147_483_648 and <= 4_294_967_295:
                buffer[0] = 4;
                BitConverter.GetBytes((uint)reading).CopyTo(buffer, 1);
                break;
            //long
            case >= 4_294_967_296 and <= long.MaxValue:
                buffer[0] = (byte)(256 - 8);
                BitConverter.GetBytes(reading).CopyTo(buffer, 1);
                break;
            //long
            case >= long.MinValue and <= -2_147_483_649:
                buffer[0] = (byte)(256 - 8);
                BitConverter.GetBytes(reading).CopyTo(buffer, 1);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(reading), "Value is out of supported range");
        }
        return buffer;
        
    }

    public static long FromBuffer(byte[] buffer)
    {
        if(buffer.Length != 9) { return 0;}
        byte prefixByte = buffer[0];

        byte[] restOfBuffer = buffer.Skip(1).ToArray();

        return prefixByte switch 
        {
            2 => BitConverter.ToUInt16(restOfBuffer,0),
            254 => BitConverter.ToInt16(restOfBuffer, 0),
            4 => BitConverter.ToUInt32(restOfBuffer, 0),
            252 => BitConverter.ToInt32(restOfBuffer, 0),
            8 => BitConverter.ToInt64(restOfBuffer, 0),
            248 => BitConverter.ToInt64(restOfBuffer, 0),
            _=> 0
        };   
    }


}
