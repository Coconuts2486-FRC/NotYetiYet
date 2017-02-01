using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coconuts.Vision.PixyLibs
{
    class PixyHandler
    {
        /// <summary>
        /// Initializes the Pixy. Must be called before any code.
        /// </summary>
        /// <returns>Status code of initialization.</returns>
        public static int Init()
        {
            int statusCode = pixy.pixy_init();
            return statusCode;
        }

        /// <summary>
        /// Get the detected items of the pixy.
        /// </summary>
        /// <param name="MaxBlocks">Max number of blocks to get.</param>
        /// <param name="Blocks">Block array to store blocks in. Uses pointers to automatically set the object.</param>
        /// <returns>The number of objects detected in the frame.</returns>
        public static int GetBlocks(ushort MaxBlocks, BlockArray Blocks)
        {
            int returnData = pixy.pixy_get_blocks(MaxBlocks, Blocks);
            return returnData;
        }

        /// <summary>
        /// Destruct the Pixy.
        /// </summary>
        public static void Close()
        {
            pixy.pixy_close();
        }
    }
}
