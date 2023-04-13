# ECommerce Project



.Net 3.1 versiyonu ile bir e ticaret projesi olu�turulacak. Proje i�erisinde temelde 3 katman tan�mlanacak bu katmanlar;

	## NetEcommerce.Entity => Veri taban�nda tablo haline gelmesini istedi�imiz classlar� bar�nd�ran katman.
		- katmanda kullan�lan paketler;
			#### Microsoft.AspNetCore.Identity.EntityFrameworkCore
	### Base
	### Entity
	### Enum
	### Interface


	## NetEcommerce.DAL=> Veri taban� ile ileti�im halinde olan katman.
	- katmanda kullan�lan paketler;
			#### Microsoft.AspNetCore.Identity.EntityFrameworkCore
			#### Microsoft.EntityFrameworkCore.SqlServer
			#### Microsoft.EntityFrameworkCore.Tools

	### Context
		#### ProjectContext

	## NetEcommerce.BLL => DAL (Data Access Layer) ile ileti�im halinde olarak, al�nan bilgileri Listeleme,Olu�turma,G�ncelleme,Silme eylemlerini ger�ekle�tirecek olan katman



	//#1 nolu issue yap�ld�.
