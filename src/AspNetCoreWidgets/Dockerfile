FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["AspNetCoreWidgets/AspNetCoreWidgets.csproj", "AspNetCoreWidgets/"]
RUN dotnet restore "AspNetCoreWidgets/AspNetCoreWidgets.csproj"
COPY . .
WORKDIR "/src/AspNetCoreWidgets"
RUN dotnet build "AspNetCoreWidgets.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "AspNetCoreWidgets.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AspNetCoreWidgets.dll"]