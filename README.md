# Проект API для электронной доски объявлений. SolarLab

Чтобы приложение смогло подключиться к базе данных, сперва следует запустить проект для миграции базы данных. Для этого в корне приложения нужно ввести:
### dotnet run --project src/Board/Host/Board.Host.Migrator 
или же запустить его любым другим способом.

<pre>

</pre>

Затем можно запускать проект с API:
### dotnet run --project src/Board/Host/Board.Host.Api
или же другим способом.

<pre>

</pre>

После этого в браузере автоматически откроется Swagger UI, в котором можно совершать все запросы к API. 

![изображение](https://github.com/Asphalteight/ElectronicBoard/assets/128236389/896ca388-8ba8-4ad7-9128-9b6d8bea02bd)

#### API будет расположено по адресу https://localhost:7089
#### Пользовательский интерфейс - по адресу https://localhost:7089/swagger/index.html
