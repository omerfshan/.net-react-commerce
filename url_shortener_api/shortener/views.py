from django.shortcuts import render
from rest_framework import viewsets, status
from rest_framework.decorators import action
from rest_framework.response import Response
from django.shortcuts import redirect, get_object_or_404
from .models import URL
from .serializers import URLSerializer

# Create your views here.

class URLViewSet(viewsets.ModelViewSet):
    queryset = URL.objects.all().order_by('-created_at')
    serializer_class = URLSerializer

    def create(self, request, *args, **kwargs):
        serializer = self.get_serializer(data=request.data)
        serializer.is_valid(raise_exception=True)
        self.perform_create(serializer)
        headers = self.get_success_headers(serializer.data)
        return Response(serializer.data, status=status.HTTP_201_CREATED, headers=headers)

    @action(detail=False, methods=['get'], url_path='redirect/(?P<short_code>[^/.]+)')
    def redirect(self, request, short_code=None):
        url = get_object_or_404(URL, short_code=short_code)
        url.clicks += 1
        url.save()
        return redirect(url.original_url)
