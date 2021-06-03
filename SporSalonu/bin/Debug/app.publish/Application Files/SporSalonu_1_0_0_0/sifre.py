import hashlib
import csv
import re
from dataclasses import dataclass

# TODO: default şifre "00000000" oluşturulacak

PSW = "psw.csv"
csv.register_dialect('myDialect', delimiter='|', quoting=csv.QUOTE_NONE, skipinitialspace=True, quotechar='')


def hasher(value):
	"""
	Sha-256 algoritmasını kullananan hash fonksiyonu

	:param value: şifrelenecek string
	:type value: str
	:rtype: string
	:return: sha-256 algoritmasına göre hashlenmiş metin
	"""
	encrypter = hashlib.sha256()
	encrypter.update(value.encode("utf-8"))
	return encrypter.hexdigest()


@dataclass
class Password:
	"""
	Şifre veri sınıfı

	:param psw: hashlenmiş şifre metni
	:type psw: str
	"""
	psw: str

	def __init__(self, psw: str):
		"""
		Password sınıfının yapıcı metodu

		:param psw: hashlenmemiş şifre metni
		:type psw: str
		"""
		self.psw = psw

	@staticmethod
	#@classmethod  # TODO: araştırılacak
	def kayit(password: str) -> object:
		"""
		Password sınıfının kayıt metodu

		Yapıcı metodu direk çağırmak yerine gerekli kontroller yapılarak kayit(password)
		metodu kullanılmalıdır

		:param password: hashlenmemiş şifre metni
		:type password: str
		:rtype: object
		:return: Girilen şifre kontrol edilir ve geriye Password nesnesi dönülür
		eğer mevcutta böyle bir şifre varsa None döner
		"""
		if Password.sifreOku(password) == "sifre mevcut" or not re.match('[0-9]{8}', password):
			print("sifre zaten mevcut!")
			return None
		else:
			return Password(password)

# TODO: getter-setter methodlarının dosctring tarzı araştırılacak
# region getter-setter methods
	@property
	def psw(self) -> str:
		"""
		psw değişkeninin getter metodu

		:rtype: str
		:return: Girilen şifre psw ye aktarılır ve geri dönüş sağlanır.
		"""
		return self._psw

	@psw.setter
	def psw(self, value) -> None:
		"""
		psw değişkeninin setter metodu

		Kontrol sağladığımızda eşleşme olmazsa
		etkileşimi için konsola bilgilendirme metni basılır

		:param value: hashlenmemiş şifre metninin Setter'i
		:type value: str
		:rtype: str
		"""
		if re.match('[0-9]{8}', value):
			value = hasher(value)
			self._psw = value
		else:
			print("Geçerli bir şifre giriniz([0-9]{8})!")

# endregion

	@staticmethod
	def sifreYaz(password: object) -> None:
		"""
		Kayıt edilecek şifrelerin dosyaya yazımı için metod

		:param password: kayit metodundan dönen Password nesnesi
		:type password: object
		:rtype: None
		:return: None
		Geriye değer dönülmez fakat .Net etkileşimi için konsola bilgilendirme metni basılır
		"""
		try:
			if password is not None:
				with open(PSW, mode='a', encoding='utf-8', newline='') as writeFile:
					writer = csv.writer(writeFile, 'myDialect')
					temp = [password.psw]
					writer.writerow(temp)
					#print("Yeni şifre eklendi!")
		except FileNotFoundError:
			if password is not None:
				with open(PSW, mode='w', encoding='utf-8', newline='') as writeFile:
					writer = csv.writer(writeFile, 'myDialect')
					# default "00000000"
					temp = [password.psw, hasher("00000000")]
					writer.writerows(temp)
					print("Yeni şifre eklendi!")

	@staticmethod
	def sifreOku(password: str) -> str:
		"""
		Kayıt edilecek şifrelerin dosyaya okuması için metod

		:param password: kayit metodundan dönen Password nesnesi
		:type password: str
		:rtype: None
		:return: None
		Geriye değer dönülmez fakat etkileşimi için konsola bilgilendirme metni basılır eğer
		try da çalışmazise excepte düşer ve şifre mevcut değil bilgisini ekrana basar
		"""
		try:
			with open(PSW, mode='r', encoding='utf-8', newline='') as readerFile:
				reader = csv.reader(readerFile, 'myDialect')
				for row in reader:
					if hasher(password) in row:
						return f"sifre mevcut"
				return f"sifre mevcut degil"

		except FileNotFoundError:
			
			with open(PSW, mode='w', encoding='utf-8', newline=''):
				# default "00000000"
				Password.sifreYaz(Password.kayit(password))
				return f"sifre mevcut"
					

