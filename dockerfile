FROM texlive/texlive
LABEL description="texlive with pygments for minted support"
RUN apt-get update -y && \
    apt-get install -y python3-pygments && \
    rm -rf /var/lib/apt/lists/*