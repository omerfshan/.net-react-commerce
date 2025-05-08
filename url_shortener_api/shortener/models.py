from django.db import models
import string
import random

def generate_short_code():
    length = 6
    while True:
        code = ''.join(random.choices(string.ascii_letters + string.digits, k=length))
        if not URL.objects.filter(short_code=code).exists():
            return code

class URL(models.Model):
    original_url = models.URLField(max_length=2048)
    short_code = models.CharField(max_length=6, unique=True, default=generate_short_code)
    created_at = models.DateTimeField(auto_now_add=True)
    clicks = models.IntegerField(default=0)

    def __str__(self):
        return f"{self.original_url} -> {self.short_code}"
