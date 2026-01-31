# Jellyfin OpenLibrary Metadata Provider Plugin

A Jellyfin plugin that provides book and author metadata from [OpenLibrary.org](https://openlibrary.org).

## Features

- **Book Metadata Provider**: Fetches comprehensive metadata for books including:
  - Book descriptions/overviews
  - Series information
  - Publication dates
  - Genres/subjects
  - Author information with biographies

- **Author/Person Metadata Provider**: Fetches author metadata including:
  - Author names
  - Biographies
  - Birth and death dates

## Installation

### From Jellyfin Plugin Repository

1. In Jellyfin, go to **Dashboard** → **Plugins** → **Catalog**
2. Find **OpenLibrary** in the metadata section
3. Click **Install**
4. Restart Jellyfin

### Manual Installation

1. Download the latest release from the releases page
2. Extract the contents to your Jellyfin plugins directory:
   - Linux: `/var/lib/jellyfin/plugins/OpenLibrary/`
   - Windows: `%AppData%\Jellyfin\Server\plugins\OpenLibrary\`
3. Restart Jellyfin

## Configuration

### Enable the Provider

1. Go to **Dashboard** → **Libraries**
2. Select your book library (or create one if you haven't)
3. Click on **Manage Library** → **Metadata downloaders**
4. Enable **OpenLibrary** for books and/or authors
5. Optionally, adjust the priority order of metadata providers

### Scan Your Library

After enabling the provider, scan or refresh metadata for your book library to fetch data from OpenLibrary.

## How It Works

The plugin uses the OpenLibrary API to:

1. Search for books by title
2. Fetch detailed book information from both the Works and Editions endpoints
3. Retrieve author information and biographies
4. Map the data to Jellyfin's metadata structure

No API key is required as the OpenLibrary API is free and open.

## Data Sources

- **Search API**: `https://openlibrary.org/search.json`
- **Works API**: `https://openlibrary.org/works/{id}.json`
- **Editions API**: `https://openlibrary.org/books/{id}.json`
- **Authors API**: `https://openlibrary.org/authors/{id}.json`

## Limitations

- The plugin does not currently support image retrieval
- Book matching is based on title search, which may not always return exact matches
- OpenLibrary's metadata coverage varies by book

## Building from Source

### Requirements

- .NET 9.0 SDK
- Jellyfin 10.9.0 or higher

### Build Steps

```bash
git clone <repository-url>
cd jellyfin-plugin-openlibrary
dotnet build
```

The compiled plugin will be in `Jellyfin.Plugin.OpenLibrary/bin/Debug/net9.0/`.

## Contributing

Contributions are welcome! Please feel free to submit issues or pull requests.

## License

This plugin is licensed under the GNU General Public License v3.0. See [LICENSE](LICENSE) for details.

## Acknowledgments

- Data provided by [OpenLibrary](https://openlibrary.org), a project of the Internet Archive
- Based on the [Jellyfin Plugin Template](https://github.com/jellyfin/jellyfin-plugin-template)
