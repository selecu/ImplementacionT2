var MyPlugin = {
    DownloadImageJs: function(bytes, size, name)
    {
        var newBytes = new Uint8Array(size);
        var convertedText = Pointer_stringify(name);
        for(var i = 0; i < size; i++)
        {
            newBytes[i] = HEAPU8[bytes + i];
        }

        DownloadImage(newBytes, convertedText);
    }
};

mergeInto(LibraryManager.library, MyPlugin);
