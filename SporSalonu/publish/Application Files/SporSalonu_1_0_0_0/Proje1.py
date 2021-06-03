# -*- coding: utf-8 -*-
import csv
import errno
import re
import sys
import os
from sifre import Password
from Programs import Program as pr
"""from pandasgui import show
import pandas as pd"""

UYE_TABLO = "uyeTablo.csv"
girisCikisPath = "GirisCikis/"

# yazma-okuma işlemleri için parametreler
csv.register_dialect("myDialect", delimiter='|', quoting=csv.QUOTE_NONE, skipinitialspace=True, quotechar="")
csv.register_dialect("myDialectp", delimiter='\n', quoting=csv.QUOTE_NONE, skipinitialspace=True, quotechar="")


def tr_title(paramWord: str) -> str:
	"""
	Türkçe harfler için title fonksiyonu

	title() fonksiyonunda 'ı' ve 'i' harflerine yaşanan sorunlar sebebiyle hazırlanan metod.

	:param paramWord: Sadece baş harflerinin büyük olması istenen string
	:type paramWord: str
	:rtype: str
	:returns: Türkçe harfler de sorunsuz şekilde title edildikten sonra geri döndürülen string
	"""
	wordList = paramWord.split(sep=" ")
	newWord = ""

	for word in wordList:
		firstLetter = word[0]
		lastPart = word[1:]

		firstLetter = re.sub(r"ç", "Ç", firstLetter)
		firstLetter = re.sub(r"ğ", "Ğ", firstLetter)
		firstLetter = re.sub(r"ı", "I", firstLetter)
		firstLetter = re.sub(r"i", "İ", firstLetter)
		firstLetter = re.sub(r"ö", "Ö", firstLetter)
		firstLetter = re.sub(r"ş", "Ş", firstLetter)
		firstLetter = re.sub(r"ü", "Ü", firstLetter)

		lastPart = re.sub(r"Ç", "ç", lastPart)
		lastPart = re.sub(r"Ğ", "ğ", lastPart)
		lastPart = re.sub(r"I", "ı", lastPart)
		lastPart = re.sub(r"İ", "i", lastPart)
		lastPart = re.sub(r"ö", "Ö", lastPart)
		lastPart = re.sub(r"Ş", "ş", lastPart)
		lastPart = re.sub(r"Ü", "ü", lastPart)

		rebuiltWord = firstLetter + lastPart

		rebuiltWord = rebuiltWord.capitalize()  # türkçe olmayan harfler için capitalize fonksiyonu
		newWord = newWord + " " + rebuiltWord

	newWord = newWord.strip()
	return newWord


class BadCommandError(Exception):
	"""
	Class for BadCommandError

	Güncelleme metodu için custom exception
	"""
	pass


class Uyeler:
	salonAdi = "Kardeşler Spor Salonu"

	def __init__(self, Id: str, ad: str, soyad: str, yas: str, cinsiyet: str, boy: str, kilo: str, telefon: str, emailadress: str, dogumTarihi: str, aboneTip: str, fiyat: str, kayitTarihi: str):
		"""
		Uyeler sınıfının yapıcı metodu

		:param Id: Kimlik numarası
		:type Id: str
		:param ad: Üyenin adı
		:type ad: str
		:param soyad: Üyenin soyadı
		:type soyad: str
		:param yas: Üyenin yaşı
		:type yas: str
		:param cinsiyet: Üyenin cinsiyeti, vücut kitle indeksi için gereklidir
		:type yas: str
		:param boy: Üyenin boyu(cm)
		:type boy: str
		:param kilo: Üyenin vicut ağırlığı(kg)
		:type kilo: str
		:param telefon: Üyenin telefon numarası
		:type telefon: str
		:param emailadress: Üyenin e-mail adresi
		:type emailadress: str
		:param dogumTarihi: Üyenin doğum tarihi
		:type dogumTarihi: str
		:param aboneTip: Abonelik pakedi(süre)
		:type aboneTip: str
		:param fiyat: Aylık abonelik ücreti(TL)
		:type fiyat: str
		:param kayitTarihi: Üyenin aboneliğinin başlangıç tarihi
		:type kayitTarihi: str
		"""
		self.Id = Id
		self.ad = tr_title(ad)
		self.soyad = tr_title(soyad)
		self.yas = yas
		self.cinsiyet = cinsiyet
		self.boy = boy
		self.kilo = kilo
		self.telefon = telefon
		self.emailadress = emailadress
		self.dogumTarihi = dogumTarihi
		self.aboneTip = aboneTip
		self.fiyat = fiyat
		self.kayitTarihi = kayitTarihi

	@staticmethod
	#@classmethod # TODO: araştırılacak
	def kayit(Id: str, ad: str, soyad: str, yas: str, cinsiyet: str, boy: str, kilo: str, telefon: str, emailadress: str, dogumTarihi: str, aboneTip: str, fiyat: str, kayitTarihi: str) -> object:
		"""
		Üye kayıt metodu

		arama metoduyla daha önceki kayıtlı üyeler kontrol edilir.
		Eğer yeni üye benzersizse geriye obje döner.
		Eğer yeni üye benzersiz değilse geriye None döner.

		:param Id: Kimlik numarası
		:type Id: str
		:param ad: Üyenin adı
		:type ad: str
		:param soyad: Üyenin soyadı
		:type soyad: str
		:param yas: Üyenin yaşı
		:type yas: str
		:param cinsiyet: Üyenin cinsiyeti, vücut kitle indeksi için gereklidir
		:type yas: str
		:param boy: Üyenin boyu(cm)
		:type boy: str
		:param kilo: Üyenin vicut ağırlığı(kg)
		:type kilo: str
		:param telefon: Üyenin telefon numarası
		:type telefon: str
		:param emailadress: Üyenin e-mail adresi
		:type emailadress: str
		:param dogumTarihi: Üyenin doğum tarihi
		:type dogumTarihi: str
		:param aboneTip: Abonelik pakedi(süre)
		:type aboneTip: str
		:param fiyat: Aylık abonelik ücreti(TL)
		:type fiyat: str
		:param kayitTarihi: Üyenin aboneliğinin başlangıç tarihi
		:type kayitTarihi: str
		:rtype: object
		:returns: Eğer yeni üye benzersizse geriye obje döner. Eğer yeni üye benzersiz değilse geriye None döner.
		"""
		if Uyeler.arama(Id) is None:  # yeni kayıt için daha önceki üyeler kontrol
			print(f"{Id} numaralı üye oluşturuluyor.")
			return Uyeler(Id, ad, soyad, yas, cinsiyet, boy, kilo, telefon, emailadress, dogumTarihi, aboneTip, fiyat, kayitTarihi)
		else:
			print(f"{Id} numaralı üye zaten kayıtlı.")
			return None

	def serialize(self) -> list:  # üye bilgilerinin yazıya dökümü
		"""
		Uyeler sınıfının bilgilerini listelemek için metod

		:rtype: list
		:returns: Uyeler sınıfının özellikleri string listesi olarak döndürülür.
		"""
		return [str(self.Id), self.ad, self.soyad, self.yas, self.cinsiyet, self.boy, self.kilo,
				str(self.telefon), self.emailadress, str(self.dogumTarihi), self.aboneTip, self.fiyat, self.kayitTarihi]

	def yazma(self):  # bir üyenin bilgilerinin dosyaya yazımı
		"""
		Bir üyenin bilgilerinin ikincil belleğe kayıt edilmesi için hazırlanan metod

		serialize() metodundan dönen liste csv dosyasına kaydedilir. csv dosyası incelediğinde her satırda bir üyenin bilgilerinin
		bilgilerinin tutulduğu görülebilir.
		"""
		liste = self.serialize()
		with open(UYE_TABLO, mode='a', encoding="utf-8", newline='') as writeFile:
			writer = csv.writer(writeFile, 'myDialect')
			writer.writerow(liste)

	@staticmethod
	def okuma() -> list:
		"""
		Üye listesini okumak için hazırlanan metod

		uyeTablo.csv dosyası okunur ve geriye lsite olarak döndürülür.

		:returns: uyeTablo.csv dosyası okunup liste olarak döndürülür
		:rtype: list
		"""
		liste = []
		try:
			with open(UYE_TABLO, mode='r', encoding="utf-8") as readerFile:
				reader = csv.reader(readerFile, 'myDialect')
				for row in reader:
					liste.append(row)

		except FileNotFoundError:
			#print("exception dosya bulunamadı")
			with open(UYE_TABLO, mode='w', encoding="utf-8",):
				pass
			"""file = open(UYE_TABLO, mode='w', encoding="utf-8")
			file.close()"""

		return liste

	@staticmethod
	def aramaListe(aranan: str) -> list:
		"""
		İsimle arama yapmak için hazırlanan metod

		:param aranan: Aranan üyenin adı veya soyadı
		:type aranan: str
		:return: Aranan isimle eşleşen Üyelerin listesi
		:rtype: list
		"""
		arananL = []
		if (aranan.isdigit()):
			return Uyeler.arama(aranan)

		if not (aranan.istitle()):
			aranan = tr_title(aranan)
			temp = aranan.split(" ")
			if len(temp) > 1:
				arananL.append(' '.join(temp[0:-1]))
				arananL.append(temp[-1])
			elif len(temp) == 1:
				temp = str(temp).strip("[']")
				arananL.append(temp)
		bulunanL = []
		for uye in Uyeler.okuma():
			for elem in arananL:
				if elem in uye[1] or elem == uye[2]:
					bulunanL.append(f"{uye[0]}|{uye[1]}|{uye[2]}")
					break
		if len(bulunanL) == 0:
			return None
		return bulunanL

	@staticmethod
	def arama(aranan: str) -> object:
		"""
		Kimlik numarası ile arama yapmak için hazırlanan metod.

		Üye listesinde kimlik numarası ile arama yapıldıktan sonra eşleşen üye bilgileri geriye döndürülür.

		:param aranan: Aranan üyenin kimlik numarası
		:type aranan: str
		:returns: Bulunan üyenin bilgileri '|' karakteri ile birleştirilerek döndürülür
		:rtype: str
		"""
		# id ile arama
		for uye in Uyeler.okuma():
			if aranan == uye[0]:
				uye = '|'.join([str(elem) for elem in uye])
				print(uye)  # .Net etkileişimi için konsola bastırılır.
				return uye
		return None


	@staticmethod
	def silme(silinecekUye: str, command: str):
		"""
		Üye silmek veya güncellemek için hazırlanan metod

		Metod "sil" komutuyla çağırılırsa parametre olarak verilen kimlik numaralı üyenin bilgileri silinir.
		Metod "update" komutuyla çağırılırsa parametre olarak verilen kimlik numaralı üye listeden güncellenmek üzere silinir.
		Geriye silinen üyenin satır numarası ve üyesi silinmiş liste döndürülür.
		Eğer gerçersiz bir komut parametre olarak verilirse custom bir exception fırlatılır.

		:param silinecekUye: Silinmek istenen üyenin kimlik numarası
		:type silinecekUye:	str
		:param command: yapılmak istenen işlem
		:type command: str
		:raises BadCommandError: Metod eğer "sil" veya "update" dışında bir komutla çağırılırsa custom bir exception fırlatılır
		:returns: Metod eğer "sil" komutuyla çağırıldıysa herhnagi bir şey dönülmez, metod "update" komutuyla çağırıldıysa
		geriye silinen üyenin satır numarası ve üyesi silinmiş liste döndürülür
		:rtype: tuple
		"""
		ind = None  # dosyanın sırasını bozmamak için indis değeri
		liste = Uyeler.okuma()

		if command == "sil":
			for ind, uye in enumerate(liste):
				if silinecekUye in uye:
					liste.pop(ind)
					with open(UYE_TABLO, mode='w', encoding="utf-8", newline='') as writeFile:
						writer = csv.writer(writeFile, 'myDialect')
						writer.writerows(liste)
					print("Üye başarıyla silinmiştir.")
					pr.programSil(silinecekUye)
					Uyeler.girisCikisSil(silinecekUye)
					break

		elif command == "update":
			for ind, uye in enumerate(liste):
				if silinecekUye in uye:
					liste.pop(ind)
					pr.programSil(silinecekUye)
					Uyeler.girisCikisSil(silinecekUye)
					return ind, liste
			return None
		else:
			raise BadCommandError("Bad command: %s" % command)

	@staticmethod
	def guncelleme(guncelUye: list):
		"""
		Üye güncellemek için hazırlanan method

		silme() metodu "update" komutuyla çağırılır, üyenin eski bilgileri silinir, silem metodundan geriye satır numarası
		ve silinmiş üye listesi döner, güncellenmiş bilgiler listeye eklenir ve dosyaya yazım yapılır.
		Yapılan işlemin başarılı olup olmadığı konsola yazdırılır.

		:param guncelUye: Güncel üye bilgileri
		:type guncelUye: list
		"""
		indis, liste = Uyeler.silme(str(guncelUye[0]), "update")
		if indis is not None:
			yeniUye = Uyeler(guncelUye[0], guncelUye[1], guncelUye[2], guncelUye[3], guncelUye[4], guncelUye[5],
							 guncelUye[6], guncelUye[7], guncelUye[8], guncelUye[9], guncelUye[10], guncelUye[11], guncelUye[12])
			if yeniUye:
				liste.insert(indis, yeniUye.serialize())

			# TODO: dosyayı baştan yazmak yerine yeni dosya oluşturmayı da deneyebilirsin

			with open(UYE_TABLO, mode='w', encoding="utf-8", newline='') as writeFile:
				writer = csv.writer(writeFile, 'myDialect')
				writer.writerows(liste)
			print("Üye başarıyla güncellenmiştir.")

	@staticmethod
	def girisCikisDosya(Id: str):
		"""
		Giriş-çıkış bilgilerinin tutulduğu klasörün ve dosyanın oluşturulduğu metod

		:param Id: Kimlik numarası
		:type Id: str
		"""
		try:
			with open(girisCikisPath + Id + ".csv", mode='w', encoding="utf-8"):
				pass
		except OSError as exc:
			if exc.errno != errno.EEXIST:
				os.mkdir(os.getcwd() + "/GirisCikis/")
			with open(girisCikisPath + Id + ".csv", mode='w', encoding="utf-8"):
				pass

	@staticmethod
	def giris(Id: str, tarih: str, saat: str):
		"""
		Bir üyenin salona giriş tarihi ve saatini tutmak için hazırlanan metod

		Uyenin Id'si adında csv dosyasına giriş tarih ve saatini yazar.

		:param Id: Kimlik numarası
		:type Id: str
		:param tarih: DD.MM.YYYY formatındaki tarih bilgisi
		:type tarih: str
		:param saat: HH.MM formatındaki saat bilgisi
		:type saat: str
		"""
		try:
			with open(girisCikisPath + Id + ".csv", mode='a', encoding='utf-8', newline='') as writeFile:
				writer = csv.writer(writeFile, 'myDialect')
				writer.writerow([f"Giriş tarihi: {tarih}", f"Giriş saati: {saat}"])
		except OSError as exc:
			if exc.errno != errno.EEXIST:
				os.mkdir(os.getcwd() + "/GirisCikis/")
				with open(girisCikisPath + Id + ".csv", mode='w', encoding="utf-8", newline='') as writeFile:
					writer = csv.writer(writeFile, 'myDialect')
					writer.writerow([f"Giriş tarihi: {tarih}", f"Giriş saati: {saat}"])

	@staticmethod
	def cikis(Id: str, tarih: str, saat: str):
		"""
		Bir üyenin salona çıkış tarihi ve saatini tutmak için hazırlanan metod

		Uyenin Id'si adında csv dosyasına çıkış tarih ve saatini yazar.

		:param Id: Kimlik numarası
		:type Id: str
		:param tarih: DD.MM.YYYY formatındaki tarih bilgisi
		:type tarih: str
		:param saat: HH.MM formatındaki saat bilgisi
		:type saat: str
		"""
		try:
			with open(girisCikisPath + Id + ".csv", mode='a+', encoding='utf-8', newline='') as file:
				"""reader = csv.reader(file, 'myDialect')
				file.seek(len(reader))"""

				writer = csv.writer(file, 'myDialect')
				writer.writerow([f"Çıkış tarihi: {tarih}", f"Çıkış saati: {saat}"])
		except OSError as exc:
			if exc.errno != errno.EEXIST:
				os.mkdir(os.getcwd() + "/GirisCikis/")
				with open(girisCikisPath + Id + ".csv", mode='w', encoding="utf-8", newline='') as writeFile:
					writer = csv.writer(writeFile, 'myDialect')
					writer.writerow([f"Çıkış tarihi: {tarih}", f"Çıkış saati: {saat}"])

	@staticmethod
	def girisCikisSil(Id: str):
		"""
		Kaydı silinen üyenin giriş-çıkış verilerini de diskten silmek için hazırlanan metod

		:param Id: Kimlik numarası
		:type Id: str
		"""
		try:
			os.remove(girisCikisPath + Id + ".csv")
		except Exception as e:
			print('Silme hatası: ' % e)

	@staticmethod  # TODO: sınıf metodu değil
	def hesaplamalar(cinsiyetBoyKilo: str):
		"""
		fonksiyon başlığı

		detaylı açıklama

		:param cinsiyetBoyKilo: sdfsdf
		:type cinsiyetBoyKilo: str
		:return: sdfsdfsdf
		:rtype: str
		"""
		liste = cinsiyetBoyKilo.split('|')
		cinsiyet 	= liste[0]
		boy 		= liste[1]
		kilo		= liste[2]
		netYag = pr.netYagHesaplama(cinsiyet, int(boy), int(kilo))
		yagsizKilo = pr.yagsizKiloHesapla(cinsiyet, int(boy), int(kilo))
		boyKiloEnd = pr.boyKiloEndeks(int(boy), int(kilo))

		return (f"{netYag:.2f}|{yagsizKilo:.2f}|{boyKiloEnd}").replace(' ', ';')
		

# region getter-setter methods
	@property
	def Id(self) -> str:
		"""
		Kimlik numarası getter

		:return: Üyenin kimlik numarası
		:type: str
		"""
		"""if re.match("[0-9]{11}", self.Id):
			raise ValueError("Geçersiz kimlik numarası")"""
		return self._Id

	@Id.setter
	def Id(self, value: str):
		"""
		Kimlik numarası setter

		:param value: Girilen kimlik numarası
		:type value: str
		"""
		self._Id = value

	@property
	def ad(self) -> str:
		"""
		Ad getter

		:return: Üyenin adı
		:rtype: str
		"""
		return self._ad

	@ad.setter
	def ad(self, value: str):
		"""
		Ad setter

		:param value: Girilen ad
		:type value: str
		"""
		self._ad = value

	@property
	def soyad(self) -> str:
		"""
		Soyad getter

		:return: Üyenin soyadı
		:rtype: str
		"""
		return self._soyad

	@soyad.setter
	def soyad(self, value: str):
		"""
		Soyad setter

		:param value: Girilen soyad
		:type value:str
		"""
		self._soyad = value

	@property
	def yas(self) -> str:
		"""
		Yaş getter

		:return: Üyenin yaşı
		:rtype: str
		"""
		return self._yas

	@yas.setter
	def yas(self, value: str):
		"""
		Yaş setter

		:param value: Girilen yaş
		:type value: str
		"""
		self._yas = value

	@property
	def cinsiyet(self) -> str:
		"""
		Cinsiyet getter

		:return: Üyenin cinsiyeti
		:rtype: str
		"""
		return self._cinsiyet

	@cinsiyet.setter
	def cinsiyet(self, value: str):
		"""
		Cinsiyet setter

		:param value: Girilen cinsiyet
		:type value: str
		"""
		self._cinsiyet = value

	@property
	def boy(self) -> str:
		"""
		Boy getter

		:return: Üyenin boyu(cm)
		:rtype: str
		"""
		return self._boy

	@boy.setter
	def boy(self, value: str):
		"""
		Boy setter

		:param value: Girilen boy(cm)
		:type value: str
		"""
		self._boy = value

	@property
	def kilo(self) -> str:
		"""
		Kilo getter

		:return: Üyenin vücut ağırlığı(kg)
		:rtype: str
		"""
		return self._kilo

	@kilo.setter
	def kilo(self, value: str):
		"""
		Kilo setter

		:param value: Girilen vücut ağırlığı(kg)
		:type value: str
		"""
		self._kilo = value

	@property
	def telefon(self) -> str:
		"""
		Telefon getter

		:return: Üyenin telefon numarası
		:rtype: str
		"""
		return self._telefon

	@telefon.setter
	def telefon(self, value: str):
		"""
		Telefon setter

		:param value: Girilen telefon numarası
		:type value: str
		"""
		self._telefon = value

	@property
	def emailadress(self) -> str:
		"""
		E-mail address getter

		:return: Üyenin e-mail adresi
		:rtype: str
		"""
		return self._emailadress

	@emailadress.setter
	def emailadress(self, value: str):
		"""
		E-mail address setter

		:param value: Girilen e-mail adresi
		:type value: str
		"""
		self._emailadress = value

	@property
	def dogumTarihi(self) -> str:
		"""
		Doğum tarihi getter

		:return: Üyenin doğum tarihi
		:rtype: str
		"""
		return self._dogumTarihi

	@dogumTarihi.setter
	def dogumTarihi(self, value: str):
		"""
		Doğum tarihi setter

		:param value: Girilen doğum tarihi
		:type value: str
		"""
		self._dogumTarihi = value

	@property
	def aboneTip(self) -> str:
		"""
		Abonelik tipi getter

		:return: Üyenin abonelik tipi
		:rtype: str
		"""
		return self._aboneTip

	@aboneTip.setter
	def aboneTip(self, value: str):
		"""
		Abonelik tipi setter

		:param value: Girilen abonelik tipi
		:type value: str
		"""
		self._aboneTip = value

	@property
	def fiyat(self) -> str:
		"""
		Fiyat getter

		:return: Üyenin aylık abonelik ücreti
		:rtype: str
		"""
		return self._fiyat

	@fiyat.setter
	def fiyat(self, value: str):
		"""
		Fiyat setter

		:param value: Girilen aylık abonelik ücreti
		:type value: str
		"""
		self._fiyat = value

	@property
	def kayitTarihi(self) -> str:
		"""
		Kayıt tarihi getter

		:return: Üyenin kayıt tarihi(abonelik başlangıç tarihi)
		:rtype: str
		"""
		return self._kayitTarihi

	@kayitTarihi.setter
	def kayitTarihi(self, value: str):
		"""
		Kayıt tarihi setter

		:param value: Girilen kayıt tarihi(abonelik başlangıç tarihi)
		:type value: str
		"""
		self._kayitTarihi = value

# endregion

def okumaListe() -> list:
	"""
	Bütün üyelerin listelenmesi için hazırlana method

	:return: Üyelerin listesi
	:rtype:list
	"""
	uyeler = Uyeler.okuma()
	yeniUyeler = [convertFromUye(elem) for elem in uyeler]
	return yeniUyeler

def convertToUye(veri: str) -> object:
	"""
	 Terminalden gelen string haldeki üye verilerini Üye sınıfının kayıt fonksiyonunun aldığı parametrelere uygun hale getirilmesi
	işlemini gerçekleştirir. 

	:param veri: Terminalden gelen string haldeki üye verileri
	:type veri: str
	:return: Yeni kayıt edilecek üye nesnesi
	:rtype: object
	"""
	uye = veri.split('|')
	return Uyeler.kayit(uye[0], uye[1], uye[2], uye[3], uye[4], uye[5], uye[6], uye[7], uye[8], uye[9], uye[10], uye[11], uye[12])

def convertToUyeUp(veri: str) -> list:
	"""
	Güncellenecek bilgilerin guncelleme() metoduna uygun hale getirilmesi için hazırlanan metod
	
	:param veri: Terminalden gelen string haldeki üye verileri
	:type veri: str
	:return: Üye verilerini bulunduğu bir liste
	:rtype: list
	"""
	uye = veri.split('|')
	return uye

def convertFromUye(uye: list) -> str:
	"""
	 Üye sınıfı türünde, üye verilerini içeren bir listeyi terminalden okunabilecek bir formda stringe çeviren method
	
	:param uye: Üye verilerini içeren liste
	:type uye: list
	:return: Belirli bir formda string
	:rtype: str
	"""
	return f"{uye[0]}|{uye[1]}|{uye[2]}|{uye[3]}|{uye[4]}|{uye[5]}|{uye[6]}|{uye[7]}|{uye[8]}|{uye[9]}|{uye[10]}|{uye[11]}|{uye[12]}"

def replaceProgram(program: str) -> list:
	"""
	 Terminale, terminalden okunabilecek bir forma çevrilmiş şekilde yazdırlılan string halindeki programı eski haline çeviren method.

	:param program: String halde gelen program
	:type program: str
	:return: Eski haline çevrilen programı liste halinde döner
	:rtype: list
	"""
	program = program.replace(';', ' ')
	#program = program.replace('*', '\n')
	#program = program.split()
	program = program.split('|')
	temp = []
	for day in program:
		temp.append(day.split('*'))
	return temp

def convertToPassword(psw: str) -> object:
	"""
	Yönetici şifreleri oluşturmak için hazırlanan metod

	:param psw: Haslenmemiş şifre metn,
	:type psw: str
	:return: Hashlenmiş şifre nesnesi
	:rtype: object
	"""
	return Password.kayit(psw)

islem = sys.argv[1]
# Bu if statementları terminalden alınan argüman 1'e göre farklı işlemler yapabilmemizi sağlar
if islem == 'w':
	a = convertToUye(sys.argv[2])
	if a is not None:
		a.yazma()

elif islem == 'r':
	a = Uyeler.aramaListe(sys.argv[2])
	if type(a) is list:
		print(a)
	elif a is str:
		print(convertFromUye(a)) #convertfromUye() ihtiyaç yok zaten str dönüyor

elif islem == 'ra':
	a = okumaListe()
	print(a)

elif islem == 'g':
	a = Uyeler.guncelleme(convertToUyeUp(sys.argv[2]))

elif islem == 'pw':
	print(sys.argv[3])
	pr.programYaz(replaceProgram(sys.argv[3]), sys.argv[2])

elif islem == 'pr':
	print(pr.programOku(sys.argv[2]))

elif islem == 's':
	a = Uyeler.silme(sys.argv[2], "sil")

elif islem == 'c':
	print(Uyeler.hesaplamalar(sys.argv[2]))
	
elif islem == 'cid':
	Uyeler.giris(sys.argv[2], sys.argv[3], sys.argv[4])

elif islem == 'cod':
	Uyeler.cikis(sys.argv[2], sys.argv[3], sys.argv[4])

elif islem == 'ap':
	print(Password.sifreYaz(convertToPassword(sys.argv[3])))

elif islem == 'gp':
	print(Password.sifreOku(sys.argv[2]))
