# Stage 1
FROM node as builder
WORKDIR /app
COPY src/BolaoShow.SPA ./
COPY src/BolaoShow.SPA/package.json ./
RUN npm install
RUN npm run build

# stage: 2 — the production environment
FROM nginx:alpine
COPY src/BolaoShow.SPA/nginx.conf /etc/nginx/conf.d/default.conf
COPY --from=builder /app/build /usr/share/nginx/html
CMD ["/bin/sh", "-c", "exec nginx -g 'daemon off;';"]