FROM mcr.microsoft.com/dotnet/sdk:8.0-preview AS build-env

# the source code will be copied in /src
WORKDIR /src

# by copying only the csproj files we can leverage build layer caching.
# this means that this layer of the image will be rebuilt only if the csproj file change, such as new packages added.
COPY ["src/TornTracker.TimedWorker/TornTracker.TimedWorker.csproj", "TornTracker.TimedWorker/"]
COPY ["src/TornTracker.Application/TornTracker.Application.csproj", "TornTracker.Application/"]
COPY ["src/TornTracker.Domain/TornTracker.Domain.csproj", "TornTracker.Domain/"]
COPY ["src/TornTracker.Infrastructure/TornTracker.Infrastructure.csproj", "TornTracker.Infrastructure/"]
RUN dotnet restore "TornTracker.TimedWorker/TornTracker.TimedWorker.csproj"

# after restoring all packages, we can copy the whole source code.
# please note that the files copied are relative to the build context, and the .dockerignore file tells Docker which
# files to copy and which to not copy.
COPY ["src/TornTracker.TimedWorker/.", "TornTracker.TimedWorker/"]
COPY ["src/TornTracker.Domain/.", "TornTracker.Domain/"]
COPY ["src/TornTracker.Application/.", "TornTracker.Application/"]
COPY ["src/TornTracker.Infrastructure/.", "TornTracker.Infrastructure/"]

# at this point we can build and publish the app to the /out dir
RUN dotnet publish --no-restore -c Release -o out TornTracker.TimedWorker/TornTracker.TimedWorker.csproj

# this is a multi stage build, so the build process happens on the sdk base image and the final image
# uses only the runtime/aspnet image, to minimize the size of the resulting image
FROM mcr.microsoft.com/dotnet/aspnet:8.0-preview

# the final app will run inside the /app directory
WORKDIR /app

# we can copy the build result from the previous build stage into this one
COPY --from=build-env ["/src/out", "."]

# the entrypoint of the application is our dll file run by the dotnet CLI
ENTRYPOINT ["dotnet", "TornTracker.TimedWorker.dll"]