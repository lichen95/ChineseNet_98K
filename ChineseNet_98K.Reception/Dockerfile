#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk-nanoserver-sac2016 AS build
WORKDIR /src
COPY ["ChineseNet_98K.Reception/ChineseNet_98K.Reception.csproj", "ChineseNet_98K.Reception/"]
COPY ["ChineseNet_98K.Entity/ChineseNet_98K.Entity.csproj", "ChineseNet_98K.Entity/"]
COPY ["ChineseNet_98K.IDAL/ChineseNet_98K.IDAL.csproj", "ChineseNet_98K.IDAL/"]
COPY ["ChineseNet_98K.Common/ChineseNet_98K.Common.csproj", "ChineseNet_98K.Common/"]
COPY ["ChineseNet_98K.IBLL/ChineseNet_98K.IBLL.csproj", "ChineseNet_98K.IBLL/"]
COPY ["ChineseNet_98K.BLL/ChineseNet_98K.BLL.csproj", "ChineseNet_98K.BLL/"]
COPY ["ChineseNet_98K.DAL/ChineseNet_98K.DAL.csproj", "ChineseNet_98K.DAL/"]
RUN dotnet restore "ChineseNet_98K.Reception/ChineseNet_98K.Reception.csproj"
COPY . .
WORKDIR "/src/ChineseNet_98K.Reception"
RUN dotnet build "ChineseNet_98K.Reception.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ChineseNet_98K.Reception.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ChineseNet_98K.Reception.dll"]
