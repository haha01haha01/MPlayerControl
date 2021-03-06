﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

namespace MplayerUnitTests
{

    [TestFixture()]
    public class Mencoder_Test
    {


        [Test()]
        public void Convert2WebMTest()
        {
            var a = new LibMPlayerCommon.Mencoder();
            a.Convert2WebM(GlobalVariables.Video8Path, GlobalVariables.OutputVideoWebM);
        }

        [Test()]
        public async void Convert2WebMAsyncTest()
        {
            var a = new LibMPlayerCommon.Mencoder();
            await a.Convert2WebMAsync(GlobalVariables.Video8Path, GlobalVariables.OutputVideoWebM);
        }


        [Test()]
        public void Convert2X264Test()
        {
            var a = new LibMPlayerCommon.Mencoder();
            a.Convert2X264(GlobalVariables.Video8Path, GlobalVariables.OutputVideoX264);
        }

        [Test()]
        public async void Convert2X264AsyncTest()
        {
            var a = new LibMPlayerCommon.Mencoder();
            await a.Convert2X264Async(GlobalVariables.Video8Path, GlobalVariables.OutputVideoX264);
        }

        [Test()]
        public void Convert2DvdMpegPalTest()
        {
            var a = new LibMPlayerCommon.Mencoder();
            a.Convert2DvdMpeg(LibMPlayerCommon.Mencoder.RegionType.PAL, GlobalVariables.Video8Path, GlobalVariables.OutputVideoDvdMpegPal);
        }

        [Test()]
        public async void Convert2DvdMpegPalAsyncTest()
        {
            var a = new LibMPlayerCommon.Mencoder();
            await a.Convert2DvdMpegAsync(LibMPlayerCommon.Mencoder.RegionType.PAL, GlobalVariables.Video8Path, GlobalVariables.OutputVideoDvdMpegPal);
        }

        [Test()]
        public void Convert2DvdMpegNtscTest()
        {
            var a = new LibMPlayerCommon.Mencoder();
            a.Convert2DvdMpeg(LibMPlayerCommon.Mencoder.RegionType.NTSC, GlobalVariables.Video8Path, GlobalVariables.OutputVideoDvdMpegNtsc);

            a.ConversionComplete += a_ConversionComplete;
        }

        [Test()]
        public async void Convert2DvdMpegNtscAsyncTest()
        {
            var a = new LibMPlayerCommon.Mencoder();
            await a.Convert2DvdMpegAsync(LibMPlayerCommon.Mencoder.RegionType.NTSC, GlobalVariables.Video8Path, GlobalVariables.OutputVideoDvdMpegNtsc);

        }

        private void a_ConversionComplete(object sender, LibMPlayerCommon.MplayerEvent e)
        {
            var a = new LibMPlayerCommon.Discover(GlobalVariables.OutputVideoDvdMpegNtsc, GlobalVariables.MplayerPath);
            Assert.AreEqual(192, a.AudioBitrate);
            Assert.AreEqual(720, a.Width);
            Assert.AreEqual(480, a.Height);
            Assert.AreEqual(48000, a.AudioSampleRate);

        }
    }
}
