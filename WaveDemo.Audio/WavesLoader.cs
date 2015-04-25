using SharpDX.IO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;

namespace WaveDemo.Audio {
    public static class WavesLoader {
        public static async Task<Dictionary<string, NativeFileStream>> LoadWavesFromFolder(string path) {
            var folder = await StorageFolder.GetFolderFromPathAsync(path);
            var files = await folder.GetFilesAsync();
            var streams = new Dictionary<string, NativeFileStream>();
            foreach (var file in files) {
                var stream = new NativeFileStream(file.Path, NativeFileMode.Open, NativeFileAccess.Read);
                streams.Add(file.Name, stream);
            }
            return streams;
        }
    }
}
