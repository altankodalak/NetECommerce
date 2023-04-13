# ECommerce Project



.Net 3.1 versiyonu ile bir e ticaret projesi oluþturulacak. Proje içerisinde temelde 3 katman tanýmlanacak bu katmanlar;

	## NetEcommerce.Entity => Veri tabanýnda tablo haline gelmesini istediðimiz classlarý barýndýran katman.
		- katmanda kullanýlan paketler;
			#### Microsoft.AspNetCore.Identity.EntityFrameworkCore
	### Base
	### Entity
	### Enum
	### Interface


	## NetEcommerce.DAL=> Veri tabaný ile iletiþim halinde olan katman.
	- katmanda kullanýlan paketler;
			#### Microsoft.AspNetCore.Identity.EntityFrameworkCore
			#### Microsoft.EntityFrameworkCore.SqlServer
			#### Microsoft.EntityFrameworkCore.Tools

	### Context
		#### ProjectContext

	## NetEcommerce.BLL => DAL (Data Access Layer) ile iletiþim halinde olarak, alýnan bilgileri Listeleme,Oluþturma,Güncelleme,Silme eylemlerini gerçekleþtirecek olan katman



	//#1 nolu issue yapýldý.
